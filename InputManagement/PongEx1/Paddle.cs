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
    class Paddle:PongEntity, ICollidable,IKeyboardListener
    {
        private IList<Keys> keyList;
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        //initialise the ball
        public override void Initialise()
        {
           
        }
        public int Height()
        {
            return texture.Height;
        }
        public int Width()
        {
            return texture.Width;
        }
        public void onCollide(IEntity entity)
        {
            
        }

        public override void Update()
        {
            //update the paddles position
            entityLocn.Y +=velocity.Y*2;
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
        public virtual void OnNewInput(object source, InputEventArgs args)
        {
            // Act on data:
            keyList = args.PressedKeys;
            foreach (Keys key in keyList)
            {
                if (key == Keys.W)
                {
                    velocity.Y -= 0.2f;
                }
                else if(key==Keys.S)
                {
                    velocity.Y += 0.2f;
                }
            }

        }
    }
}
