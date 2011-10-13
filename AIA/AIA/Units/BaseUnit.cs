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
	public class BaseUnit : BasePlace
	{
		private float m_fVelocity;
			public float MaxVelocity
			{
				set
				{
					m_fVelocity = value;
				}
				get
				{
					return m_fVelocity;
				}
			}

        private float m_fDamage;
			public float Damage
			{
				set
				{
					m_fDamage = value;
				}
				get
				{
					return m_fDamage;
				}
			}

         private float m_fAttackSpeed;
			public float AttackSpeed
			{
				set
				{
					m_fAttackSpeed = value;
				}
				get
				{
					return m_fAttackSpeed;
				}
			}

        private float m_fRange;
			public float Range
			{
				set
				{
					m_fRange = value;
				}
				get
				{
					return m_fRange;
				}
			}

        public void unitMove(Vector2 targetPosition)
        {
            this.Particle.Mass = 1000;
            //   this.Particle.Pos = targetPosition;
            this.Particle.Zero();
            Console.WriteLine(targetPosition);
            Console.WriteLine(this.Particle.Pos);
            if (this.Particle.Pos != targetPosition)
            {
                this.Particle.ApplyForce(new Vector2((targetPosition.X - this.Particle.Pos.X) / 10,
                (targetPosition.Y - this.Particle.Pos.Y) / 10));
            }
            else
            {
                this.Particle.ApplyForce(new Vector2(0, 0));
            }
        }

	}
}
