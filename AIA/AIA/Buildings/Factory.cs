using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIA
{
    class Factory : BaseBuilding
    {

        public Factory(){
            Texture = AssetManager.getInstance().getTexture("Factory");
        }

    }
}
