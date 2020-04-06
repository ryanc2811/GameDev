using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Collision;
namespace PongEx1.Entities
{
    class Wall : GameXEntity, ICollidable,IImmovable
    {
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            
        }
    }
}
