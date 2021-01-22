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
using GameEngine.Kernel;
using GameEngine.BehaviourManagement;

namespace Pong.EntityMinds
{
    class PaddleAI : PongAI, IInputListener, ICollidable
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;

        public override void Initialise()
        {
            gameObject.UpdateMind += Update;
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, gameObject.GetTexture().Width, gameObject.GetTexture().Height);
        }

        public void OnCollide(IAIComponent entity)
        {
            
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            gameObject.Velocity=new Vector2(gameObject.Velocity.X, 0);
            Vector2 v = gameObject.Velocity;
            keyList = args.PressedKeys;
            if (gameObject.Position.X == 1550)
            {
                if (keyList.Contains(Keys.Up))
                {
                    v.Y -= 15f;
                    //update the paddles position
                    gameObject.Position=new Vector2(gameObject.Position.X,gameObject.Position.Y + v.Y);
                    gameObject.Velocity= v;
                }
                else if (keyList.Contains(Keys.Down))
                {
                    v.Y += 15f;
                    //update the paddles position
                    gameObject.Position = new Vector2(gameObject.Position.X, gameObject.Position.Y + v.Y);
                    gameObject.Velocity = v;
                }
            }
            if (gameObject.Position.X == 0)
            {
                if (keyList.Contains(Keys.W))
                {
                    v.Y -= 15f;
                    //update the paddles position
                    gameObject.Position = new Vector2(gameObject.Position.X, gameObject.Position.Y + v.Y);
                    gameObject.Velocity = v;
                }
                else if (keyList.Contains(Keys.S))
                {
                    v.Y += 15f;
                    //update the paddles position
                    gameObject.Position = new Vector2(gameObject.Position.X, gameObject.Position.Y + v.Y);
                    gameObject.Velocity = v;
                }
            }
        }
        public override void Update()
        {
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (gameObject.Position.Y < 0)
            {
                gameObject.Position = new Vector2(gameObject.Position.X, 0);
            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (gameObject.Position.Y >= Kernel.SCREENHEIGHT - 150)
            {
                gameObject.Position = new Vector2(gameObject.Position.X, Kernel.SCREENHEIGHT - 150);
            }
        }
    }
}
