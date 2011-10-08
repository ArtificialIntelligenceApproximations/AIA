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
	/// Contains most of the internal physics properties of a sprite
	/// </summary>
	public class Particle
	{

		private Vector2 _Pos;
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
		private Vector2 _Velocity;
			public Vector2 Velocity 
			{
				get 
				{
					return _Velocity;
				}
				set 
				{
					_Velocity = value;
				}
			}
		private Vector2 _Acceleration;
			public Vector2 Acceleration
			{
				get 
				{
					return _Acceleration;
				}
				set 
				{
					_Acceleration = value;
				}
			}
		
		private float _Mass;
			public float Mass
			{
				get 
				{
					return _Mass;
				}
				set
				{
					_Mass = value;
				}
			}
		
		
		//interia
		//impulse
		
		/// <summary>
		/// This method handles moving the particle
		/// </summary>
		/// <param name="p_gameTime"></param>
		/// 
		public void Zero ( )
		{
			Velocity = new Vector2 ( 0.0f, 0.0f );
			Acceleration = new Vector2 ( 0.0f, 0.0f );
		}

		private void Move ( GameTime p_gameTime )
		{

			float _xChange;
			float _yChange;
			
			float _fTime = p_gameTime.ElapsedGameTime.Milliseconds;
			
			_xChange = ( Velocity.X * _fTime ) + ( 0.5f * Acceleration.X * ( _fTime * _fTime ) );
			_yChange = ( Velocity.Y * _fTime ) + ( 0.5f * Acceleration.Y * ( _fTime * _fTime ) );

			Pos = new Vector2 ( Pos.X + _xChange, Pos.Y + _yChange );

		}

		private void UpdateVelocity ( GameTime p_gameTime ) 
		{
			float _xChange;
			float _yChange;
			
			float _fTime = p_gameTime.ElapsedGameTime.Milliseconds;

			_xChange = Acceleration.X * _fTime;
			_yChange = Acceleration.Y * _fTime;

			Velocity += new Vector2 ( _xChange, _yChange );

			Velocity *= 0.9f;
		}

		private void UpdateAcceleration ( GameTime p_gameTime ) 
		{
			Acceleration *= 0.9f;
		}

		public void ApplyImpulse ( )
		{

		}

		public void ApplyForce ( Vector2 p_Force )
		{
			// F = M A
			// A = F / M

			float _fXChange = p_Force.X / Mass;
			float _fYChange = p_Force.Y / Mass;

			Acceleration = new Vector2 ( Acceleration.X + _fXChange, Acceleration.Y + _fYChange );


		}

		/// <summary>
		/// Position - Uses SUVATs based on accel + veloicty to work out screen pos change
		///					since last frame
		/// </summary>
		/// <param name="p_gameTime"></param>
		public void Update ( GameTime p_gameTime ) 
		{
			UpdateAcceleration ( p_gameTime );
			UpdateVelocity ( p_gameTime );
			Move ( p_gameTime );
		}


	}
}
