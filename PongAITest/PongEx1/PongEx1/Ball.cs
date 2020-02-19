using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PongEx1
{
    class Ball : PongEntity, ICollidable,IBall
    {
        public int speed = 20;
        public Random random;
        int PlScore = 0;
        int AIScore = 0;
        float maxAngle = 45f;

        //DECLARE integer for storing the facing direction of the ball(1=moving right, -1=moving left), Name it facingDirection
        
        float ballAngle;

        public Vector2 getBallPos() { return entityLocn; }

        public Ball()
        {
            random = new Random();
         
        }
        //Serve the ball
        public void Serve()
        {
            speed = 20;
            //place ball in the centre of the screen
            setPosition(Kernel.ScreenWidth / 2, Kernel.ScreenHeight / 2);
            ballAngle= (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
            velocity.X= (float)Math.Cos(ballAngle);
            velocity.Y= (float)Math.Sin(ballAngle);
            int rnd = random.Next(1, 3);
            //face the ball in a random direction
            if (rnd==2)
            {
                velocity.X *= -1;
            }

            velocity.X *= speed;
        }
        //check if the ball has collided with the wall
        public void CheckWallCollision()
        {
            if (entityLocn.X < 0)
            {
                //reset ball
                Serve();
                AIScore++;
                Console.WriteLine("Score Is "+PlScore+" - "+AIScore);
  
            }
            else if (entityLocn.X > Kernel.ScreenWidth - 50)
            {
                //reset ball
                Serve();
                PlScore++;
                Console.WriteLine("Score Is " + PlScore + " - " + AIScore);
            }
            //if the ball hits the top of the screen, then reverse the velocity
            else if (entityLocn.Y >= Kernel.ScreenHeight - 50)
            {
                velocity.Y *= -1;
                ballAngle = getRandomAngle();
                velocity.Y = speed * (float)Math.Sin(ballAngle);
                velocity.X = speed * (float)Math.Sin(ballAngle);

            }
            else if (entityLocn.Y < 0)
            {
                velocity.Y *= -1;
                ballAngle = getRandomAngle();
                velocity.Y = speed * -(float)Math.Sin(ballAngle);
                velocity.X = speed * (float)Math.Sin(ballAngle);
            }
        }
        //initialise the ball
        public override void Initialise()
        {
            Serve();
        }

        public float getRandomAngle(float minDegrees = 140f, float maxDegrees = 240f)
        {
            float minRadius = minDegrees * (float)Math.PI / 180;
            float maxRadius = maxDegrees * (float)Math.PI / 180;
            float randAngle = random.Next((int)minRadius,(int)maxRadius);
            return randAngle;
        }
        //balls update method
        public override void Update()
        {
            if (speed >= 30)
                speed = 30;

            //constantly check if the ball collides with the wall
            CheckWallCollision();
            //move the ball
            entityLocn += velocity;
            if (AIScore==5 || PlScore == 5)
            {
                AIScore = 0;
                PlScore = 0;
                Console.WriteLine("The match is over!");
            }
            //entityLocn.Y += speed * facingDirection;
            
        }

//*****************************************ICollidable stuff**********************************//

        Rectangle ICollidable.getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width,texture.Height);
        }

        void ICollidable.onCollide(IEntity entity)
        {
            if(entity is Paddle)
            {
                https://gamedev.stackexchange.com/questions/4253/in-pong-how-do-you-calculate-the-balls-direction-when-it-bounces-off-the-paddl 
                //create a variable that stores the y position of the ball when the collision occurs
                float onCollideY = entityLocn.Y;
                //store the y of the ball in relation to the paddle
                float onCollideRelativeY = ((Paddle)entity).entityLocn.Y - onCollideY;
                float onCollideNormalisedY = onCollideRelativeY / (((Paddle)entity).Height() / 2);
                //create a ball angle variable
                ballAngle = onCollideNormalisedY * (maxAngle * (float)Math.PI / 180);
                //move ball in the facing direction of the paddle
               
                //update the Y position with the new ball angle variable
                velocity.Y = speed * -(float)Math.Sin(ballAngle);
                //each time a paddle collides with a ball, add 3 to the speed
                speed += 3;
                //if the entity that collides with the ball is an AI
                if (entity is AI)
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
    }
}
