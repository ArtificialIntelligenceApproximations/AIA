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
	public class BasePlace : Sprite //BasePlace - base placeable sprite
	{           
		private float m_fHealth;
			public float Health
			{
				set
				{
					m_fHealth = value;
				}
				get
				{
					return m_fHealth;
				}
			}
		private float m_fArmour;
			public float Armour
			{
				set
				{
					m_fArmour = value;
				}
				get
				{
					return m_fArmour;
				}
			}
		private float m_fBuildTime;
			public float BuildTime
			{
				set 
				{
					m_fBuildTime = value;
				}
				get
				{
					return m_fBuildTime;
				}
			}
		//add hotkey code
		//add cost

		private List< BasePlace > m_lRequirement;
			public List< BasePlace > Requirements
			{
				set
				{
					m_lRequirement = value;
				}
				get
				{
					return m_lRequirement;
				}
			}
	
		public void addReq(  BasePlace p_Unit )
		{
			m_lRequirement.Add( p_Unit );
		}
		public void addReq( List< BasePlace > p_lUnit )
		{
			for ( int i = 0; i < p_lUnit.Count; i++ )
			{
				m_lRequirement.Add( p_lUnit.ElementAt( i ) );
			}
		}

		public void Build( Vector2 p_vPos)
		{

			Scale = 1.0f;
			Rotation = 0.0f;
			Colour = Color.White;

			Center = p_vPos;

			Particle.Acceleration = new Vector2 ( 0.0f, 0.0f );
			Particle.Velocity = new Vector2 ( 0.0f, 0.0f );

		}
	}
}
