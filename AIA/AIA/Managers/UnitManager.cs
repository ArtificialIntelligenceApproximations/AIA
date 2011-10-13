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
    class UnitManager
    {
        
        //stores the list of all units created.
        private List<BaseUnit> mUnits;
        public List<BaseUnit> Units
        {
            set
            {
                mUnits = value;
            }
            get
            {
                return mUnits;
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

        //Listens to input from mouse and keyboard and carries out appropriate actions
        public void KeyboardListener(KeyboardState CurrentKeyboardState, KeyboardState LastKeyboardState, MouseState CurrentMouseState, MouseState LastMouseState)
        {
            //Creates an instance of a units at the position of the mouse when V is held down and left mouse button clicked
            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
                (CurrentKeyboardState.IsKeyDown(Keys.V)))
            {
                BaseUnit newUnit;
                newUnit = new Velociraptor();
                newUnit.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mUnits.Add(newUnit);
            }

            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
    (CurrentKeyboardState.IsKeyDown(Keys.B)))
            {
                BaseUnit newUnit;
                newUnit = new BearCavalry();
                newUnit.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mUnits.Add(newUnit);
            }


            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
    (CurrentKeyboardState.IsKeyDown(Keys.T)))
            {
                BaseUnit newUnit;
                newUnit = new Tank();
                newUnit.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mUnits.Add(newUnit);
            }


        }

        //Draws all unsit to screen, should possible be in a different class ?
        public void DrawUnits(SpriteBatch p_SpriteBatch)
        {
            for (int i = 0; i < mUnits.Count(); i++)
            {
                mUnits[i].Draw(p_SpriteBatch);
            }
        }

        //Updates the list of selected units, called by selection class.
        public void UpdateSelectionList(Rectangle SelectionBox)
        {
            for (int i = 0; i < mUnits.Count(); i++)
            {
                //If selection box over units and building not in selection list add to list
                if (SelectionBox.Intersects(mUnits[i].PosRect) && !m_lSelectedUnits.Contains(mUnits[i]))
                {
                    m_lSelectedUnits.Add(mUnits[i]);
                }
                if (!SelectionBox.Intersects(mUnits[i].PosRect) && m_lSelectedUnits.Contains(mUnits[i]))
                {
                    m_lSelectedUnits.Remove(mUnits[i]);
                }

                if (m_lSelectedUnits.Contains(mUnits[i]))
                {
                    mUnits[i].Colour = Color.Red;
                }
                else
                {
                    mUnits[i].Colour = Color.White;
                }
            }
        }

        //Updates the units, called in main body update method.
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < mUnits.Count(); i++)
            {
                //Update position of units
                mUnits[i].Update(gameTime);
            }

        }

        public UnitManager()
        {
            mUnits = new List<BaseUnit>();
            m_lSelectedUnits = new List<BaseUnit>();
        }
    }
}
