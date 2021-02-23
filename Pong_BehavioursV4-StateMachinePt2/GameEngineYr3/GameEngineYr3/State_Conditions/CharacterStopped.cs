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
    class CharacterStopped : BaseCondition, IInputListener
    {
        //DECLARE a bool for checking if the character has stopped moving
        bool characterStopped = false;
        /// <summary>
        /// returns the outcome of the condition
        /// </summary>
        /// <returns></returns>
        public override bool FindOutcome()
        {
            return characterStopped;
        }
        /// <summary>
        /// Handles the input for the character to check if the character has stopped
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //If any movement keys are pressed
            if (args.PressedKeys.Contains(Keys.W) || args.PressedKeys.Contains(Keys.S) || args.PressedKeys.Contains(Keys.D) || args.PressedKeys.Contains(Keys.A))
                characterStopped = false;
            else
                characterStopped = true;
        }
        /// <summary>
        /// Exit the condition
        /// </summary>
        public override void ExitCondition()
        {
            //reset the character stopped bool
            characterStopped = false;
        }
    }
}
