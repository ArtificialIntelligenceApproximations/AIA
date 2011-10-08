using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIA
{
    class Wall : BaseBuilding
    {

        public Wall(){
            Texture = AssetManager.getInstance().getTexture("Wall");
        }
    }
}
