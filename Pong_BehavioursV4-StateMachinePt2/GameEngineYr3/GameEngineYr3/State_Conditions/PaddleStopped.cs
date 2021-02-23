using GameEngine.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class PaddleStopped:BaseCondition, IInputListener
    {
        //DECLARE a bool for checking if movement input has been pressed
        bool paddleStopped = false;
        /// <summary>
        /// Return the outcome of the condition
        /// </summary>
        /// <returns></returns>
        public override bool FindOutcome()
        {//if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (owner.Transform.position.Y < 0)
            {
                return true;
            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (owner.Transform.position.Y >= Kernel.Kernel.SCREENHEIGHT - 150)
            {
                return true;
            }
            return paddleStopped;
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
                    paddleStopped = false;
                else
                    paddleStopped = true;
            }
            if (owner.Tag == "RightPaddle")
            {
                if (args.PressedKeys.Contains(Keys.Up) || args.PressedKeys.Contains(Keys.Down))
                    paddleStopped = false;
                else
                    paddleStopped = true;
            }



        }
        /// <summary>
        /// Exits the condition
        /// </summary>
        public override void ExitCondition()
        {
            //reset input pressed bool
            paddleStopped = false;
        }
    }
}
