using GameEngine.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class PaddleMoved : BaseCondition, IInputListener
    {
        //DECLARE a bool for checking if movement input has been pressed
        bool inputPressed = false;
        /// <summary>
        /// Return the outcome of the condition
        /// </summary>
        /// <returns></returns>
        public override bool FindOutcome()
        {
            CheckOutOfBounds();
            return inputPressed;
        }
        void CheckOutOfBounds()
        {
            if (owner.Transform.position.Y < 0)
            {
                owner.SetPosition(owner.Transform.position.X, 0);
            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (owner.Transform.position.Y >= Kernel.Kernel.SCREENHEIGHT - 150)
            {
                owner.SetPosition(owner.Transform.position.X, Kernel.Kernel.SCREENHEIGHT - 150);
            }
        }
        /// <summary>
        /// Handles the input for the character to check if any movement key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //if any movement key is pressed
            if (owner.Tag == "LeftPaddle")
            {
                if (args.PressedKeys.Contains(Keys.W) || args.PressedKeys.Contains(Keys.S))
                    inputPressed = true;
                else
                    inputPressed = false;
            }
            else if (owner.Tag == "RightPaddle")
            {
                if (args.PressedKeys.Contains(Keys.Up) || args.PressedKeys.Contains(Keys.Down))
                    inputPressed = true;
                else
                    inputPressed = false;
            }
        }
        /// <summary>
        /// Exits the condition
        /// </summary>
        public override void ExitCondition()
        {
            //reset input pressed bool
            inputPressed = false;
        }
    }
}
