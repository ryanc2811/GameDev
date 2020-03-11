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
    class Paddle:PongEntity, ICollidable,IInputListener
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
            velocity.Y = 0;
            keyList = args.PressedKeys;
            if (entityLocn.X == 1550)
                {
                if (keyList.Contains(Keys.Up))
                    {
                        velocity.Y -= 15f;
                    //update the paddles position
                    entityLocn.Y += velocity.Y;
                }
                    else if (keyList.Contains(Keys.Down))
                    {
                        velocity.Y += 15f;
                    //update the paddles position
                    entityLocn.Y += velocity.Y;
                    }
                }
            if (entityLocn.X == 0)
            {
                if (keyList.Contains(Keys.W))
                {
                    velocity.Y -= 15f;
                    //update the paddles position
                    entityLocn.Y += velocity.Y;
                }
               else if (keyList.Contains(Keys.S))
               {
                    velocity.Y += 15f;
                    //update the paddles position
                    entityLocn.Y += velocity.Y;
               }
            }
        }


        }
    }

