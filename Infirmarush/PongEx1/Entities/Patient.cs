using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Illness;

namespace PongEx1.Entities
{
    class Patient : GameXEntity,ICollidable
    {
        IIllnessFactory illnessFactory;
        IIllness illness;
        public Patient()
        {
            illnessFactory = new IllnessFactory();
            illness = illnessFactory.create();
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            
        }
        public override void Update()
        {
            
            
        }
    }
}
