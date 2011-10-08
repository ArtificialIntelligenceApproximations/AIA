using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIA.Lib
{


	class Maths
	{

		public static float RandFloat ( int min, int max, int seed ) 
		{
			Random random = new Random ( seed );
			float test = ( float ) ( min + ( float ) random.NextDouble ( ) * ( max - min ) );
			return test;
		}


	}
}
