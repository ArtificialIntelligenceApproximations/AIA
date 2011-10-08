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
	class AssetManager
	{

        private static AssetManager _instance;

		List < Texture2D > _Textures;
	
		public void addTexture ( Texture2D p_Tex, String p_sName )
        {
            // Quick check to ensure this TextureName hasn't been seen before
            int i;
            for (i=0;i<_Textures.Count();i++){
                if (_Textures.ElementAt(i).Name == p_sName){
                    return;
                }
            }

			p_Tex.Name = p_sName;
			_Textures.Add ( p_Tex );
		}

		public Texture2D getTexture ( String p_sName ) 
		{
			int i;

			for ( i = 0; i < _Textures.Count( ); i++ )
			{
				if ( _Textures.ElementAt( i ).Name == p_sName ) 
				{
					return _Textures.ElementAt( i );
				}
			}

			return null;
		}

        public static AssetManager getInstance(){
            if (_instance == null)
            {
                _instance = new AssetManager();
            }
            return _instance;
        }

		private AssetManager ( )
		{
			_Textures = new List<Texture2D>( );
		}

	}


}
