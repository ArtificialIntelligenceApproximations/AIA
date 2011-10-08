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
	class Emitter
	{

		private List < Sprite > Payload;

		private List < Sprite > UnderPayload;
		private List < Sprite > OverPayload;

		private Particle _Particle;
			public Particle Particle
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
			
		private float _OverArc;
			public float OverArc
			{
				get
				{
					return _OverArc;
				}
				set
				{
					_OverArc = value;
				}
			}
		private float _UnderArc;
			public float UnderArc
			{
				get
				{
					return _UnderArc;
				}
				set
				{
					_UnderArc = value;
				}
			}
		
		private float _OverPower;
			public float OverPower
			{
				get
				{
					return _OverPower;
				}
				set
				{
					_OverPower = value;
				}
				
			}
		private float _UnderPower;
			public float UnderPower
			{
				get
				{
					return _UnderPower;
				}
				set
				{
					_UnderPower = value;
				}
			}
		
		private float _Rotation;
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

		private int _ParticleCount;
			public int ParticleCount
			{
				get
				{
					return _ParticleCount;
				}
				set
				{
					_ParticleCount = value;
				}
				
				
			}

		private Random _rand = new Random ( );

		public void setUp  ( Texture2D p_Texture, Vector2 p_pos )
		{
			Payload = new List < Sprite > ( );

			Particle.Pos = p_pos;

			

			for ( int i = 0; i < _ParticleCount; i++ )
			{
				Payload.Add ( new Sprite ( Particle.Pos, p_Texture ) );
				Payload.ElementAt ( i ).Particle.Mass = 1000.0f; 
				Payload.ElementAt ( i ).Scale = 0.4f;
			}



		}

		private void fireUnder ( )
		{
			for ( int i = 0; i < UnderPayload.Count; i++ )
			{

			}
		}

		private void fireOver ( )
		{
			for ( int i = 0; i < OverPayload.Count; i++ )
			{

			}
		}


		public void Fire (  )
		{
			
			double fireangle;


			for ( int i = 0; i < _ParticleCount; i++ )
			{
				fireangle = _rand.Next ( 0, 360 );
				
				float _xVel = ( float ) ( AIA.Lib.Maths.RandFloat ( 0 , 5, _rand.Next ( ) ) * Math.Sin ( fireangle ) );
				float _yVel = ( float ) ( AIA.Lib.Maths.RandFloat ( 0 , 5, _rand.Next ( ) ) * Math.Cos ( fireangle ) );
			
				Console.WriteLine ( _xVel );
				Console.WriteLine ( _yVel );

				Payload.ElementAt ( i ).Particle.Pos = Particle.Pos;
				Payload.ElementAt ( i ).Particle.Zero ( );
				//Payload.ElementAt ( i ).Particle.ApplyForce ( new Vector2 ( 5.0f * ( AIA.Lib.Maths.RandFloat ( -1 , 1, _rand.Next ( ) ) ), 
				//															5.0f * ( AIA.Lib.Maths.RandFloat ( -1 , 1, _rand.Next ( ) ) ) ) );
				Payload.ElementAt ( i ).Particle.ApplyForce ( new Vector2 ( _xVel, _yVel ) );
			}
		}

		public void Update ( GameTime p_GameTime )
		{
			for ( int i = 0; i < Payload.Count; i++ )
			{
				Payload.ElementAt ( i ).Update ( p_GameTime );
	
			}
		}

		public void Draw ( SpriteBatch p_SpriteBatch )
		{
			for ( int i = 0; i < Payload.Count; i++ )
			{
				Payload.ElementAt ( i ).Draw ( p_SpriteBatch );
	
			}
		}

		public Emitter ( )
		{
			Particle = new Particle ( );
		}
		public Emitter ( int p_ParticleCount ) 
		{
			ParticleCount = p_ParticleCount;
			Particle = new Particle ( );

		}

	}
}
