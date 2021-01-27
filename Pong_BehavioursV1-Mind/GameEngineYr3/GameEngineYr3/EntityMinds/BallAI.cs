using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Collision;
using GameEngine.Entities;
using Pong.Entities;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using GameEngine.Kernel;
using GameEngine.BehaviourManagement;

namespace Pong.EntityMinds
{
    class BallAI:PongAI,ICollidable,IInputListener
    {

        #region Variables
        //DECLARE speed
        public int speed = 20;
        //DECLARE random number generator
        public Random random;
        //DECLARE float for the max angle of the ball's bounce
        float maxAngle = 45f;
        //DECLARE float for storing the angle of the ball's bounce
        float ballAngle;
        #endregion region

        public BallAI()
        {
            random = new Random();
        }
        public override void Initialise()
        {
            gameObject.UpdateMind += Update;
            Serve();
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, gameObject.GetTexture().Width, gameObject.GetTexture().Height);
        }
        #region Serve
        //Serve the ball i.e begin the game
        public void Serve()
        {
            //ASSIGN speed value
            speed = 15;
            //place ball in the centre of the screen
            gameObject.Position= new Vector2(Kernel.SCREENWIDTH / 2, Kernel.SCREENHEIGHT / 2);
            //CALCULATE the rotation
            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
            
            //Launch ball diagonally
            gameObject.Velocity=new Vector2((float)Math.Sin(rotation), (float)Math.Cos(rotation));
            //Create random number between 1 and 2
            int rnd = random.Next(1, 3);
            //launch the ball in a random direction
            if (rnd == 2)
            {
                gameObject.Velocity = new Vector2(gameObject.Velocity.X * -1, gameObject.Velocity.Y);
            }

            gameObject.Velocity=new Vector2(gameObject.Velocity.X *speed,gameObject.Velocity.Y);
        }
        #endregion
        public void OnCollide(IAIComponent entity)
        {
            //IF ball collided with paddle
            if (entity is PaddleAI)
            {

            https://gamedev.stackexchange.com/questions/4253/in-pong-how-do-you-calculate-the-balls-direction-when-it-bounces-off-the-paddl 
                //create a variable that stores the y position of the ball when the collision occurs
                float onCollideY = gameObject.Position.Y;
                //store the y of the ball in relation to the paddle
                float onCollideRelativeY = entity.GetPosition().Y - onCollideY;
                float onCollideNormalisedY = onCollideRelativeY / (entity.Height() / 2);
                //create a ball angle variable
                ballAngle = onCollideNormalisedY * (maxAngle * (float)Math.PI / 180);
                //move ball in the facing direction of the paddle

                //update the Y position with the new ball angle variable
                gameObject.Velocity= new Vector2(gameObject.Velocity.X,speed * -(float)Math.Sin(ballAngle));
                if (speed < 30)
                    //each time a paddle collides with a ball, add 3 to the speed
                    speed += 3;
                //if the entity that collides with the ball is an AI
                //Console.WriteLine(speed);
                if (entity.GetPosition().X == 1550)
                {
                    //add the ball angle variable to the velocity on the x axis
                    gameObject.Velocity= new Vector2 (speed * -(float)Math.Cos(ballAngle),gameObject.Velocity.Y);
                }
                else
                {
                    //add the ball angle variable to the velocity on the x axis
                    gameObject.Velocity = new Vector2(speed * (float)Math.Cos(ballAngle), gameObject.Velocity.Y);
                }
            }
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            
        }

        #region get random angle
        //METHOD returns the angle with value in range 140 to 240 in float variable
        public float getRandomAngle(float minDegrees = 140f, float maxDegrees = 240f)
        {
            float minRadius = minDegrees * (float)Math.PI / 180;
            float maxRadius = maxDegrees * (float)Math.PI / 180;
            float randAngle = random.Next((int)minRadius, (int)maxRadius);
            return randAngle;
        }
        #endregion
        #region Collision
        //check if the ball has collided with the wall
        public void CheckWallCollision()
        {
            //if ball reached left side of the screen
            if (gameObject.Position.X < 0)
            {
                //reset ball
                Serve();

            }
            //if ball reached right side of the screen
            else if (gameObject.Position.X > Kernel.SCREENWIDTH - 50)
            {
                //reset ball
                Serve();
            }
            //if the ball hits the top of the screen, then reverse the velocity
            else if (gameObject.Position.Y >= Kernel.SCREENHEIGHT - 50 || gameObject.Position.Y < 0)
            {
                gameObject.Velocity= new Vector2(gameObject.Velocity.X,gameObject.Velocity.Y * -1);
            }
        }
        #endregion

        public override void Update()
        {
            //constantly check if the ball collides with the wall
            CheckWallCollision();
            //move the ball
            gameObject.Position += gameObject.Velocity;
            //gameObject.Position.Y += speed * facingDirection;
        }
    }
}
