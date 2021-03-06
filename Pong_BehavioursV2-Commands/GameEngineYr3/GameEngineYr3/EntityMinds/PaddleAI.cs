﻿using System;
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
using Pong.Commands;

namespace Pong.EntityMinds
{
    class PaddleAI : PongAI, IInputListener, ICollidable
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;

        public PaddleAI()
        {
            commandManager = new CommandManager();
        }
        public override void Initialise()
        {
            speed = 15;
        }
        public Rectangle GetHitBox()
        {
            return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, Width(), Height());
        }

        public void OnCollide(IAIComponent entity)
        {
            
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            velocity.Y = 0;
            keyList = args.PressedKeys;
            if (gameObject.Position.X == 1550)
            {
                if (keyList.Contains(Keys.Up))
                {
                    velocity.Y -= speed;
                    //update the paddles position
                    commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));
                }
                else if (keyList.Contains(Keys.Down))
                {
                    velocity.Y += speed;
                    //update the paddles position
                    commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));
                }
            }
            if (gameObject.Position.X == 0)
            {
                if (keyList.Contains(Keys.W))
                {
                    velocity.Y -= speed;
                    //update the paddles position
                    commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));
                }
                else if (keyList.Contains(Keys.S))
                {
                    velocity.Y +=speed;
                    //update the paddles position
                    commandManager.ExecuteCommand(new MoveCommand(gameObject, velocity));
                }
                
            }
            if (keyList.Contains(Keys.Back))
            {
                commandManager.Undo();
            }
        }
        public override void Update()
        {
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (gameObject.Position.Y < 0)
            {
                commandManager.ExecuteCommand(new RepositionCommand(gameObject, new Vector2(gameObject.Position.X,0)));
            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (gameObject.Position.Y >= Kernel.SCREENHEIGHT - 150)
            {
                commandManager.ExecuteCommand(new RepositionCommand(gameObject, new Vector2(gameObject.Position.X, Kernel.SCREENHEIGHT - 150)));
            }
        }
    }
}
