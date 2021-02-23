using GameEngine.Animation_Stuff;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class CharacterMoveCommand : BaseCommand, IInputListener
    {
        //DECLARE a Vector2 for calculating the velocity of the Character
        private Vector2 velocity;
        public override void Execute()
        {
            
        }
        /// <summary>
        /// Handles the movement of the character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //reset velocity
            velocity = Vector2.Zero;
            float speed = 2f;
            //If Character moving forward
            if (args.PressedKeys.Contains(Keys.W))
            {
                //Play move up animation
                ((IAnimatedSprite)owner).GetAnimationManager().Play("moveUp");
                //move forward
                velocity.Y -= speed;
            }
            //if character moving backwards
            else if (args.PressedKeys.Contains(Keys.S))
            {
                ///Play move down animation
                ((IAnimatedSprite)owner).GetAnimationManager().Play("moveDown");
                //move backwards
                velocity.Y += speed;
            }
            //if character moving right
            else if (args.PressedKeys.Contains(Keys.D))
            {
                //play move right animation
                ((IAnimatedSprite)owner).GetAnimationManager().Play("moveRight");
                //move right
                velocity.X += speed;
            }
            //if character moving left
            else if (args.PressedKeys.Contains(Keys.A))
            {
                //play move left animation
                ((IAnimatedSprite)owner).GetAnimationManager().Play("moveLeft");
                //move left
                velocity.X -= speed;
            }
            //Pass velocity values to the AIUser
            owner.SetVelocity(velocity.X, velocity.Y);
        }
    }
}
