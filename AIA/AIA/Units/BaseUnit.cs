using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIA
{
	public class BaseUnit : BasePlace
	{
		private float m_fSpeed;
			public float MaxSpeed
			{
				set
				{
					m_fSpeed = value;
				}
				get
				{
					return m_fSpeed;
				}
			}
		private float m_fVelocity;
			public float Velocity
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

	}
}
