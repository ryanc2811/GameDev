using GameEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class PaddleMoveCommand : BaseCommand, IInputListener
    {
        Vector2 velocity;
        public override void Execute()
        {
            
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            velocity = Vector2.Zero;
            float speed = 10f;

            if (owner.Tag == "LeftPaddle")
            {
                //If Character moving forward
                if (args.PressedKeys.Contains(Keys.W))
                {
                    //move forward
                    velocity.Y -= speed;
                }
                //if character moving backwards
                else if (args.PressedKeys.Contains(Keys.S))
                {
                    //move backwards
                    velocity.Y += speed;
                }
            }
            if(owner.Tag == "RightPaddle")
            {
                //If Character moving forward
                if (args.PressedKeys.Contains(Keys.Up))
                {
                    //move forward
                    velocity.Y -= speed;
                }
                //if character moving backwards
                else if (args.PressedKeys.Contains(Keys.Down))
                {
                    //move backwards
                    velocity.Y += speed;
                }
            }
            
            //Pass velocity values to the AIUser
            owner.SetVelocity(velocity.X, velocity.Y);
        }
    }
}
