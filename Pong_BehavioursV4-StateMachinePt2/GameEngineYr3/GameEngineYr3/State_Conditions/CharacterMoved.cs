using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.Input;
using Microsoft.Xna.Framework.Input;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class CharacterMoved : BaseCondition, IInputListener
    {
        //DECLARE a bool for checking if movement input has been pressed
        bool inputPressed = false;
        /// <summary>
        /// Return the outcome of the condition
        /// </summary>
        /// <returns></returns>
        public override bool FindOutcome()
        {
            return inputPressed;
        }
        /// <summary>
        /// Handles the input for the character to check if any movement key is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //if any movement key is pressed
            if (args.PressedKeys.Contains(Keys.W) || args.PressedKeys.Contains(Keys.S) || args.PressedKeys.Contains(Keys.D) || args.PressedKeys.Contains(Keys.A))
                inputPressed = true;
            else
                inputPressed = false;
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
