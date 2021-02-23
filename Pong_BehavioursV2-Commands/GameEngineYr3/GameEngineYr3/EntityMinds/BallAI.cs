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
using Pong.Commands;
using Microsoft.Xna.Framework.Input;

namespace Pong.EntityMinds
{
    class BallAI:PongAI,ICollidable,IInputListener
    {

        #region Variables
        //DECLARE random number generator
        public Random random;
        //DECLARE float for the max angle of the ball's bounce
        float maxAngle = 45f;
        //DECLARE float for storing the angle of the ball's bounce
        float ballAngle;

        private Vector2 oldVelocity;
        #endregion region

        public BallAI()
        {
            random = new Random();
            commandManager = new CommandManager();
        }
        public override void Initialise()
        {
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
            commandManager.ExecuteCommand(new RepositionCommand(gameObject, new Vector2(Kernel.SCREENWIDTH / 2, Kernel.SCREENHEIGHT / 2)));
            //CALCULATE the rotation
            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
            
            //Launch ball diagonally
            velocity=new Vector2((float)Math.Sin(rotation), (float)Math.Cos(rotation));
            //Create random number between 1 and 2
            int rnd = random.Next(1, 3);
            //launch the ball in a random direction
            if (rnd == 2)
            {
                velocity.X *= -1;
            }

            velocity.X *= speed;
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

                //update the Y position with the new ball angle variable
                velocity.Y = speed * -(float)Math.Sin(ballAngle);
                if (speed < 30)
                    //each time a paddle collides with a ball, add 3 to the speed
                    speed += 3;
                //if the entity that collides with the ball is an AI
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
            //if (args.PressedKeys != null)
            //{
            //    if (args.PressedKeys.Contains(Keys.Back))
            //    {
            //        commandManager.Undo();
            //    }
            //}
            //if(args.LeftClicked)
            //    commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));

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
                velocity.Y *= -1;
            }
        }
        #endregion

        public override void Update()
        {
            //constantly check if the ball collides with the wall
            CheckWallCollision();
            commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));
        }
    }
}
