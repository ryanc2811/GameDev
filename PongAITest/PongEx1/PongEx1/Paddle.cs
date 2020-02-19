using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class Paddle:PongEntity, ICollidable,IPaddle
    {
        //DECLARE double used to make the ball movement more realistic, by giving it spin, call it Spin
        //public float Spin = 5.5f;
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        

        //initialise the ball
        public override void Initialise()
        {
           
        }

        public void onCollide(IEntity entity)
        {
            
        }

        public override void Update()
        {
            //update the paddles position
            entityLocn.Y +=velocity.Y;
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (entityLocn.Y < 0 )
            {
                
                entityLocn.Y = 0;

            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (entityLocn.Y >= Kernel.ScreenHeight-150)
            {

                entityLocn.Y = Kernel.ScreenHeight-150;

            }
          
        }
        public int Height()
        {
            return texture.Height;
        }
        public int Width()
        {
            return texture.Width;
        }
    }
}
