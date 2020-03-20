using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;

namespace PongEx1.Entities
{
    class HitCheck : GameXEntity, ICollidable
    {
        protected bool boolHitWall = false;
        protected Vector2 tempPos;
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            if (entity is Wall)
            {
                entityLocn = tempPos;
                boolHitWall = true;
            }
            
        }
    }
}
