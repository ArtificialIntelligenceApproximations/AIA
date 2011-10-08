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
	/// Basic Sprite class - contains all of the data relevant to displaying a sprite on screen
	/// </summary>
	public class Sprite 
	{

		private Rectangle		_Rect;  // Current anim00t cell
			public Rectangle Rect
			{
				get
				{
					return _Rect;
				}
				set
				{
					_Rect = value;
				}
			}
		private Rectangle		_PosRect;
			public Rectangle PosRect
			{
				get
				{
					return _PosRect;
				}
			}
		private Vector2			_Pos; // Position on screen
			public Vector2 Pos
			{
				get
				{
					return _Pos;
				}
				set
				{
					_Pos = value;
				}
			}
		private Texture2D		_Texture; // Texture to use
			public Texture2D Texture
			{
				get
				{
					return _Texture;
				}
				set
				{
					_Texture = value;
					Rect = ( new Rectangle (0, 0, Texture.Width, Texture.Height ) );
				}
			}
		private SpriteEffects	_Effects; // flipped horiz, vert etc
			public SpriteEffects Effects
			{
				get
				{
					return _Effects;
				}
				set
				{
					_Effects = value;
				}
			}
		private Color			_Colour; // Colour changes - flash red etc
			public Color Colour
			{
				get
				{
					return _Colour;
				}
				set
				{
					_Colour = value;
				}
			}
		private float			_Rotation; // Rotation about centre
			public float Rotation
			{
				get
				{
					return _Rotation;
				}
				set
				{
					_Rotation = value;
				}
			}
		private float			_Scale; // HOW MUCH BIGGER
			public float Scale
			{
				get
				{
					return _Scale;
				}
				set
				{
					_Scale = value;
				}
			}
		private Vector2			_CenterPos;
			public Vector2 Center
			{
				set
				{
					Particle.Pos = value;
					_Pos = new Vector2( value.X - ( Texture.Width / 2 ),  value.Y - ( Texture.Height / 2 ) );
				}
				get
				{
					return Particle.Pos;
				}
			}
		private Particle _Particle;
			public Particle		Particle
		{
			get
			{
				return _Particle;
			}
			set
			{
				_Particle = value;
			}
		}
		
		//contains PArticle
		//		Particle is base of the physics 

		public virtual void Update(GameTime p_GameTime)
		{

			Particle.Update ( p_GameTime );
			Pos = new Vector2 ( Particle.Pos.X - Rect.Width / 2, Particle.Pos.Y - Rect.Height / 2 );

			_PosRect.X = ( int )Pos.X;
			_PosRect.Y = ( int )Pos.Y;
			_PosRect.Width = ( _Rect.Width );
			_PosRect.Height = ( _Rect.Height ) ;
		}

		public void Draw(SpriteBatch p_SpriteBatch)
		{
			p_SpriteBatch.Draw(_Texture, Pos, 
								_Rect, Colour, _Rotation, new Vector2(_Rect.X, _Rect.Y), _Scale ,_Effects, 0);
			
		}

		public Sprite ( ) 
		{
			Particle = new Particle ( );
		}

		public Sprite ( Vector2 p_Pos, Texture2D p_Tex )
		{	
			Particle = new Particle ( );

			Texture = p_Tex;

			Scale = 1.0f;
			Rotation = 0.0f;
			Colour = Color.White;

			Center = p_Pos;
		}



	}
}
