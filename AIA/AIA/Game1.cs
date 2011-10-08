using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AIA
{

	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
	
		BaseUnit _unitOne;

		Texture2D _unitTex;	
        Texture2D _dottedLineTex;

        BuildingManager _BuildingManager;
        InputManager _InputManager;
        Selection _selection;
        
		Emitter _Emitter = new Emitter ( 100 );
		
		public Game1 ( )
		{
			graphics = new GraphicsDeviceManager ( this );
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize ( )
		{

			this.IsMouseVisible = true;

			base.Initialize ( );
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent ( )
		{
            //Loads all the building images at the start of the game
            AssetManager.getInstance().addTexture(Content.Load<Texture2D>("Textures/Tower"), "Tower");
            AssetManager.getInstance().addTexture(Content.Load<Texture2D>("Textures/Wall"), "Wall");
            AssetManager.getInstance().addTexture(Content.Load<Texture2D>("Textures/Factory"), "Factory");

			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch ( GraphicsDevice );

			_unitTex = Content.Load< Texture2D >( "Textures/Unit" );		
            _dottedLineTex = Content.Load<Texture2D>("Textures/DottedLine");

			_Emitter.setUp ( _unitTex, new Vector2 ( 100.0f, 100.0f ) );

            _BuildingManager = new BuildingManager();
		
			_unitOne = new BaseUnit ( );
				_unitOne.Texture = _unitTex;

            _selection = new Selection(_BuildingManager);
            _selection.Texture = _dottedLineTex;

            _InputManager = new InputManager(_BuildingManager, _selection);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent ( )
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update ( GameTime gameTime )
		{
			// Allows the game to exit
			if ( GamePad.GetState ( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed )
				this.Exit ( );

            //Updates all mouse and keyboard presses.
            _InputManager.UpdateInput();       

            //Updates position of buildings
            _BuildingManager.Update(gameTime);

			if ( _InputManager.CurrentKey.IsKeyDown ( Keys.E ) )
			{
				_Emitter.Fire ( );
			}

			_unitOne.Update ( gameTime );
			
			_Emitter.Update ( gameTime );

			base.Update ( gameTime );
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw ( GameTime gameTime )
		{
			GraphicsDevice.Clear ( Color.CornflowerBlue );

			spriteBatch.Begin( );
            _selection.DrawSelectionBox(spriteBatch, _selection.Texture);

            //Draws all buildings to screen
            _BuildingManager.DrawBuildings(spriteBatch);
			_unitOne.Draw ( spriteBatch );

			_Emitter.Draw ( spriteBatch );

			spriteBatch.End( );

			// TODO: Add your drawing code here

			base.Draw ( gameTime );
		}
	}
}
