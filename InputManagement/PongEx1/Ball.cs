using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PongEx1
{
    class Ball : PongEntity, ICollidable
    {
        public int speed = 20;
        public Random random;
        
        //DECLARE integer for storing the facing direction of the ball(1=moving right, -1=moving left), Name it facingDirection
        private int facingDirection = 1;


        public Ball()
        {
            random = new Random();
        }
        //Serve the ball
        public void Serve()
        {
            
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
               velocity.X =velocity.X + ((Paddle)entity).velocity.X+((Paddle)entity).Spin;
               velocity.Y = velocity.Y + ((Paddle)entity).velocity.Y;
               velocity *=-1;
               
            }
        }
    }
}
