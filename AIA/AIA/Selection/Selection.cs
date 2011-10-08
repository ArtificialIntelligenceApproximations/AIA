using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AIA
{
    /// <summary>
    /// Selection class responsible for storing the area covered by the selection box
    /// Drawing method of the selection box
    /// Storing the list of objects currently selected
    /// </summary>
    class Selection : Sprite
    {

        //Building manager passed so UpdateSelectionList can be called.
        private BuildingManager _BuildingManager;           

        //Rectangle representing area of selection box
        private Rectangle _SelectionBox;    
            public Rectangle SelectionBox
            {
                get
                {
                    return _SelectionBox;
                }
                set
                {
                    _SelectionBox = value;
                }
            }

        //List containing the units currently selected
        private List<BaseUnit> m_lSelectedUnits;
            public List<BaseUnit> SelectedUnits
            {
                get
                {
                    return m_lSelectedUnits;
                }
                set
                {
                    m_lSelectedUnits = value;
                }
            }
        
        //Used to add a unit to the selection list
        public void UpdateSelectionUnit(BaseUnit unit)
        {
            m_lSelectedUnits.Add(unit);
        }

        //Draws the selection box to the screen
        public void DrawSelectionBox(SpriteBatch p_SpriteBatch, Texture2D _Texture)
        {
            //Draw the horizontal portions of the selection box 
            DrawHorizontalLine(_SelectionBox.Y, p_SpriteBatch,  _Texture);
            DrawHorizontalLine((_SelectionBox.Y + _SelectionBox.Height), p_SpriteBatch, _Texture);

            //Draw the verticla portions of the selection box 
            DrawVerticalLine(_SelectionBox.X, p_SpriteBatch, _Texture);
            DrawVerticalLine((_SelectionBox.X + _SelectionBox.Width), p_SpriteBatch,_Texture);
        }

        //Called by DrawSelectionBox, Draws the horizontal lines of the box
        public void DrawHorizontalLine(int yPosition, SpriteBatch p_SpriteBatch, Texture2D _Texture)
        {
            //Selecting an area to the right of the starting point
            if (_SelectionBox.Width > 0)
            {
                //Draw the line moving to the right
                for (int counter = 0; counter <= _SelectionBox.Width - 10; counter += 10)
                {
                    if (_SelectionBox.Width - counter >= 0)
                    {
                        p_SpriteBatch.Draw(_Texture, new Rectangle(_SelectionBox.X + counter, yPosition, 10, 5), Color.White);
                    }
                }
            }
            //When the width is less than 0, the user is selecting an area to the left of the starting point
            else if (_SelectionBox.Width < 0)
            {
                //Draw the line moving to the left
                for (int counter = -10; counter >= _SelectionBox.Width; counter -= 10)
                {
                    if (_SelectionBox.Width - counter <= 0)
                    {
                        p_SpriteBatch.Draw(_Texture, new Rectangle(_SelectionBox.X + counter, yPosition, 10, 5), Color.White);
                    }
                }
            }
        }

        //Called by DrawSelectionBox, Draws the vertical lines of the box
        public void DrawVerticalLine(int xPosition, SpriteBatch p_SpriteBatch, Texture2D _Texture)
        {
            //Selecting an area below the starting point
            if (_SelectionBox.Height > 0)
            {
                //Draw the line moving down
                for (int counter = -2; counter <= _SelectionBox.Height; counter += 10)
                {
                    if (_SelectionBox.Height - counter >= 0)
                    {
                        p_SpriteBatch.Draw(_Texture, new Rectangle(xPosition, _SelectionBox.Y + counter, 10, 5), new Rectangle(0, 0, _Texture.Width, _Texture.Height), Color.White, MathHelper.ToRadians(90), new Vector2(0, 0), SpriteEffects.None, 0);
                    }
                }
            }
            //Selecting an area above the starting point
            else if (_SelectionBox.Height < 0)
            {
                //Draw the line moving up
                for (int counter = 0; counter >= _SelectionBox.Height; counter -= 10)
                {
                    if (_SelectionBox.Height - counter <= 0)
                    {
                        p_SpriteBatch.Draw(_Texture, new Rectangle(xPosition - 10, _SelectionBox.Y + counter, 10, 5), Color.White);
                    }
                }
            }
        }

        //Updates the starting point of the selection box rectangle
        public void UpdateStartingPoint(int x, int y)
        {
            _SelectionBox.X = x;
            _SelectionBox.Y = y;
        }                

        //Updates the area of the selection box rectangle
        public void UpdateSelectionBox(int width, int height)       //Used to update the size of the selection box
        {
            _SelectionBox.Width = width;
            _SelectionBox.Height = height;
        }

        //Clears the selection lists
        public void ClearSelection()
        {
            m_lSelectedUnits.Clear();
        //    m_lSelectedBuildings.Clear();
        }

        //Checks the keyboard input to see if any selection actions need to be performed
        public void KeyboardListener(KeyboardState CurrentKeyboardState, KeyboardState LastKeyboardState, MouseState CurrentMouseState, MouseState LastMouseState)
        {           
            //If left button just pressed then set start position of rectangle
            if (CurrentMouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Released)
            {                
                UpdateStartingPoint(CurrentMouseState.X, CurrentMouseState.Y);

                //Clear previously selected when you left click
             //   ClearSelection();
            }

            //If the left mouse button is being held down then update the size of the rectangle.
            if (CurrentMouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Pressed)
            {
                UpdateSelectionBox((CurrentMouseState.X - SelectionBox.X), (CurrentMouseState.Y - SelectionBox.Y));
                
                //TODO: Add code so rectangle constantly updates to cope with left to right boxes and other combinations.
            }

            //Once the mouse is released 
            //Convert rectangle to a positive rectangle            
            if (CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed)
            {
                if (SelectionBox.Width < 0)
                {
                    UpdateStartingPoint((SelectionBox.X + SelectionBox.Width), SelectionBox.Y);
                    UpdateSelectionBox((SelectionBox.Width - (2 * SelectionBox.Width)), SelectionBox.Height);
                }

                if (SelectionBox.Height < 0)
                {
                    UpdateStartingPoint(SelectionBox.X, (SelectionBox.Y + SelectionBox.Height));
                    UpdateSelectionBox(SelectionBox.Width, (SelectionBox.Height - (2 * SelectionBox.Height)));
                }

                //Updates the list of selected buildings
                _BuildingManager.UpdateSelectionList(SelectionBox);

                SelectionBox = new Rectangle(0, 0, 0, 0);
                
            }
        }
        
         //initialises stuff        
        public Selection(BuildingManager BuildingManager)
        {
            _SelectionBox = new Rectangle(0, 0, 0, 0);           
            m_lSelectedUnits = new List<BaseUnit>();
            _BuildingManager = BuildingManager;
        }        
    }
}
