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
    class InputManager
    {
        //List of classes that are have inputs passed to them.
        private BuildingManager _mBuildingManager;
        private Selection _mSelection;

        //Do not require getters and setters as all values should be passed through InputListener Method
        //And all values should be set by UpdateInput
        private KeyboardState _CurrentKeyboardState; 
			public KeyboardState CurrentKey
			{
				get
				{
					return _CurrentKeyboardState;
				}
			}
        private KeyboardState _LastKeyboardState;

        private MouseState _CurrentMouseState;
        private MouseState _LastMouseState;

        //Updates all the input values
        public void UpdateInput()
        {
            _LastKeyboardState = _CurrentKeyboardState;
            _LastMouseState = _CurrentMouseState;
            _CurrentKeyboardState = Keyboard.GetState();
            _CurrentMouseState = Mouse.GetState();
            InputListener();
        }

        //Passes keyboard and mouse values to the classes that require it.
        public void InputListener()
        {
            _mBuildingManager.KeyboardListener(_CurrentKeyboardState, _LastKeyboardState, _CurrentMouseState, _LastMouseState);
            _mSelection.KeyboardListener(_CurrentKeyboardState, _LastKeyboardState, _CurrentMouseState, _LastMouseState);
        }

        //Pass the different classes that need input from a keyboard to this class
        public InputManager(BuildingManager _BuildingManager, Selection _Selection)
        {
            _mBuildingManager = _BuildingManager;
            _mSelection = _Selection;
        }
    }
}
