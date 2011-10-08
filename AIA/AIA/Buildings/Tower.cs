using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIA
{
    public class Tower : BaseBuilding
    {

        public Tower(){
            Texture = AssetManager.getInstance().getTexture("Tower");
        }

    }
}
