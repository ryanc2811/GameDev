using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Mouse
{
    class MouseEntity : GameXEntity, ICollidable,IInputListener
    {
        private float offset = 10f;
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, 1, 1);
        }

        public void onCollide(IEntity entity)
        {
            
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            entityLocn.X = args.MousePos.X - offset;
            entityLocn.Y = args.MousePos.Y - offset;
        }

        public override void Update()
        {
            
        }
    }
}
