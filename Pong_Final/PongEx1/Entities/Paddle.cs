using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.Collision;
using PongEx1.Input;
namespace PongEx1.Entities
{
    class Paddle:PongEntity, ICollidable,IInputListener
    {
        #region variables
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        
        //Return Rectangle that will be used as hit box
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }
        #endregion

        #region Initialize
        //initialise the paddle
        public override void Initialise()
        {
           
        }
        #endregion

        #region propertys
        public int Height()
        {
            //return height of the texture, witch is height of the paddle
            return texture.Height;
        }
        public int Width()
        {
            //return width of the texture, witch is width of the paddle
            return texture.Width;
        }
        #endregion

        #region OnCollide
        public void onCollide(IEntity entity)
        {
            //do nothing
        }
        #endregion

        #region Update
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
        #endregion

        #region OnNewInput
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

        #endregion
    }

}

