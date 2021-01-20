using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Collision;
using GameEngine.Entities;
using GameEngine.Input;
using Microsoft.Xna.Framework;

namespace Pong.EntityMinds
{
    class BallAI:PongAI,ICollidable,IInputListener
    {
        IEntity ball;
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)ball.GetPosition().X, (int)ball.GetPosition().Y, ball.GetTexture().Width, ball.GetTexture().Height);
        }

        public void OnCollide(IEntity entity)
        {
            //IF ball collided with paddle
            if (entity is Paddle)
            {

            https://gamedev.stackexchange.com/questions/4253/in-pong-how-do-you-calculate-the-balls-direction-when-it-bounces-off-the-paddl 
                //create a variable that stores the y position of the ball when the collision occurs
                float onCollideY = position.Y;
                //store the y of the ball in relation to the paddle
                float onCollideRelativeY = ((Paddle)entity).GetPosition().Y - onCollideY;
                float onCollideNormalisedY = onCollideRelativeY / (((Paddle)entity).Height() / 2);
                //create a ball angle variable
                ballAngle = onCollideNormalisedY * (maxAngle * (float)Math.PI / 180);
                //move ball in the facing direction of the paddle

                //update the Y position with the new ball angle variable
                velocity.Y = speed * -(float)Math.Sin(ballAngle);
                if (speed < 30)
                    //each time a paddle collides with a ball, add 3 to the speed
                    speed += 3;
                //if the entity that collides with the ball is an AI
                //Console.WriteLine(speed);
                if (entity.GetPosition().X == 1550)
                {
                    //add the ball angle variable to the velocity on the x axis
                    velocity.X = speed * -(float)Math.Cos(ballAngle);
                }
                else
                {
                    //add the ball angle variable to the velocity on the x axis
                    velocity.X = speed * (float)Math.Cos(ballAngle);
                }

            }
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            
        }

        public override void SetEntity(IEntity entity)
        {
            ball = entity;
        }

        public override void Update()
        {
            Console.WriteLine("Ball");
        }
    }
}
