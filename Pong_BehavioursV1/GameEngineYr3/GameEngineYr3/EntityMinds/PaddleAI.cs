using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Input;
using GameEngine.Collision;
using Microsoft.Xna.Framework;
using GameEngine.Entities;
using Microsoft.Xna.Framework.Input;

namespace Pong.EntityMinds
{
    class PaddleAI : PongAI, IInputListener, ICollidable
    {
        IAIUser paddle;

        //DECLARE Array List for Input
        private IList<Keys> keyList;
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)paddle.Position.X, (int)paddle.Position.Y, paddle.GetTexture().Width, paddle.GetTexture().Height);
        }

        public void OnCollide(IEntity entity)
        {
            
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            paddle.Velocity=new Vector2(paddle.Velocity.X, 0);
            Vector2 v = paddle.Velocity;
            keyList = args.PressedKeys;
            if (paddle.Position.X == 1550)
            {
                if (keyList.Contains(Keys.Up))
                {
                    v.Y -= 15f;
                    //update the paddles position
                    paddle.Position=new Vector2(paddle.Position.X,paddle.Position.Y + v.Y);
                    paddle.Velocity= v;
                }
                else if (keyList.Contains(Keys.Down))
                {
                    v.Y += 15f;
                    //update the paddles position
                    paddle.Position = new Vector2(paddle.Position.X, paddle.Position.Y + v.Y);
                    paddle.Velocity = v;
                }
            }
            if (paddle.Position.X == 0)
            {
                if (keyList.Contains(Keys.W))
                {
                    v.Y -= 15f;
                    //update the paddles position
                    paddle.Position = new Vector2(paddle.Position.X, paddle.Position.Y + v.Y);
                    paddle.Velocity = v;
                }
                else if (keyList.Contains(Keys.S))
                {
                    v.Y += 15f;
                    //update the paddles position
                    paddle.Position = new Vector2(paddle.Position.X, paddle.Position.Y + v.Y);
                    paddle.Velocity = v;
                }
            }
        }

        public override void SetAIUser(IAIUser aiUser)
        {
            paddle = aiUser;
        }

        public override void Update()
        {

            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (position.Y < 0)
            {

                position.Y = 0;

            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (position.Y >= Kernel.SCREENHEIGHT - 150)
            {

                position.Y = Kernel.SCREENHEIGHT - 150;

            }
        }
    }
}
