using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
namespace PongEx1.Entities
{
    class Player : GameXEntity, ICollidable, IInputListener
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        private float speed=10f;
        private float reducedSpeed;
        public Player()
        {
            reducedSpeed = speed *= 0.7f;
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

            if (velocity.X != 0 && velocity.Y != 0)
            {
                speed = reducedSpeed;
            }
            else
            {
                speed = 10;
            }
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (entityLocn.Y < 0)
            {

                entityLocn.Y = 0;

            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (entityLocn.Y >= Kernel.ScreenHeight - 50)
            {

                entityLocn.Y = Kernel.ScreenHeight - 50;

            }
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (entityLocn.X < 0)
            {

                entityLocn.X = 0;

            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (entityLocn.X >= Kernel.ScreenWidth-50)
            {

                entityLocn.X = Kernel.ScreenWidth-50;

            }
        }
        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            velocity = Vector2.Zero;
            keyList = args.PressedKeys;
            
        
            if (keyList.Contains(Keys.W))
            {
                velocity.Y -= speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
            }
            else if (keyList.Contains(Keys.S))
            {
                velocity.Y += speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
            }
            if (keyList.Contains(Keys.A))
            {
                velocity.X -= speed;
                //update the paddles position
                entityLocn.X += velocity.X;
            }
           
            else if (keyList.Contains(Keys.D))
            {
                velocity.X += speed;
                //update the paddles position
                entityLocn.X += velocity.X;
            }

        }
    }
}
