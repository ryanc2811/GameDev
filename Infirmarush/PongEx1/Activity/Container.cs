using Microsoft.Xna.Framework;
using PongEx1.Entities;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PongEx1.Activity
{
    class Container : GameXEntity,IShape
    {
       
       
        public int getHeight()
        {
            throw new NotImplementedException();
        }
        public int getWidth()
        {
            return texture.Width;
        }

        
    }
}
