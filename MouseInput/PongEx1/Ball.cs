using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PongEx1
{
    class Ball : PongEntity, ICollidable,IInputListener
    {
        public int speed = 20;
        public Random random;
        float maxAngle = 45f;
        float ballAngle;
        //DECLARE integer for storing the facing direction of the ball(1=moving right, -1=moving left), Name it facingDirection
        private int facingDirection = 1;


        public Ball()
        {
            random = new Random();
        }
        //Serve the ball
        public void Serve()
        {
            speed = 15;
            //place ball in the centre of the screen
            setPosition(Kernel.ScreenWidth / 2, Kernel.ScreenHeight / 2);
            float rotation= (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
            velocity.X= (float)Math.Sin(rotation);
            velocity.Y= (float)Math.Cos(rotation);
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
  
            }
            else if (entityLocn.X > Kernel.ScreenWidth - 50)
            {
                //reset ball
                Serve();
            }
            //if the ball hits the top of the screen, then reverse the velocity
            else if (entityLocn.Y >= Kernel.ScreenHeight - 50 || entityLocn.Y < 0)
            {
                velocity.Y *= -1;
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
            float randAngle = random.Next((int)minRadius, (int)maxRadius);
            return randAngle;
        }
        //balls update method
        public override void Update()
        {
            //constantly check if the ball collides with the wall
            CheckWallCollision();
            //move the ball
            entityLocn += velocity;
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
                if(speed<30)
                //each time a paddle collides with a ball, add 3 to the speed
                    speed += 3;
                //if the entity that collides with the ball is an AI
                Console.WriteLine(speed);
                if (entity.getPosition().X== 1550)
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
            if (args.LeftClicked)
            {
                Kernel.exit = true;
            }
        }
    }
}
