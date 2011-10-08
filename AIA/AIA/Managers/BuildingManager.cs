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
    class BuildingManager
    {
        
        //stores the list of all buildings created.
        private List<BaseBuilding> mBuildings;
        public List<BaseBuilding> Buildings
        {
            set
            {
                mBuildings = value;
            }
            get
            {
                return mBuildings;
            }
        }

        //List containing the buildings currently selected
        private List<BaseBuilding> m_lSelectedBuildings;
        public List<BaseBuilding> SelectedBuildings
        {
            get
            {
                return m_lSelectedBuildings;
            }
            set
            {
                m_lSelectedBuildings = value;
            }
        }

        //Listens to input from mouse and keyboard and carries out appropriate actions
        public void KeyboardListener(KeyboardState CurrentKeyboardState, KeyboardState LastKeyboardState, MouseState CurrentMouseState, MouseState LastMouseState)
        {
            //Creates an instance of a building at the position of the mouse when B is held down and left mouse button clicked
            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
                (CurrentKeyboardState.IsKeyDown(Keys.T)))
            {
                BaseBuilding newBuilding;
                newBuilding = new Tower();
                newBuilding.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mBuildings.Add(newBuilding);
            }

            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
    (CurrentKeyboardState.IsKeyDown(Keys.W)))
            {
                BaseBuilding newBuilding;
                newBuilding = new Wall();
                newBuilding.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mBuildings.Add(newBuilding);
            }


            if ((CurrentMouseState.LeftButton == ButtonState.Released && LastMouseState.LeftButton == ButtonState.Pressed) &&
    (CurrentKeyboardState.IsKeyDown(Keys.F)))
            {
                BaseBuilding newBuilding;
                newBuilding = new Factory();
                newBuilding.Build(new Vector2(CurrentMouseState.X, CurrentMouseState.Y));
                mBuildings.Add(newBuilding);
            }


        }

        //Draws all building to screen, should possible be in a different class ?
        public void DrawBuildings(SpriteBatch p_SpriteBatch)
        {
            for (int i = 0; i < mBuildings.Count(); i++)
            {
                mBuildings[i].Draw(p_SpriteBatch);
            }
        }

        //Updates the list of selected building, called by selection class.
        public void UpdateSelectionList(Rectangle SelectionBox)
        {
            for (int i = 0; i < mBuildings.Count(); i++)
            {
                //If selection box over building and building not in selection list add to list
                if (SelectionBox.Intersects(mBuildings[i].PosRect) && !m_lSelectedBuildings.Contains(mBuildings[i]))
                {
                    m_lSelectedBuildings.Add(mBuildings[i]);
                }
                if (!SelectionBox.Intersects(mBuildings[i].PosRect) && m_lSelectedBuildings.Contains(mBuildings[i]))
                {
                    m_lSelectedBuildings.Remove(mBuildings[i]);
                }

                if (m_lSelectedBuildings.Contains(mBuildings[i]))
                {
                    mBuildings[i].Colour = Color.Red;
                }
                else
                {
                    mBuildings[i].Colour = Color.White;
                }
            }
        }

        //Updates the buildings, called in main body update method.
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < mBuildings.Count(); i++)
            {
                //Update position of buildings
                mBuildings[i].Update(gameTime);
            }

        }

        public BuildingManager()
        {
            mBuildings = new List<BaseBuilding>();
            m_lSelectedBuildings = new List<BaseBuilding>();
        }
    }
}
