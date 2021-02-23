using GameEngine.Entities;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateWithInput
    {
        /// <summary>
        /// Handles the input of the state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="inputEvent"></param>
        void HandleInput(object sender, InputEventArgs inputEvent);
        /// <summary>
        /// Stores the event for the input
        /// </summary>
        Action<object, InputEventArgs> InputEvent{get;set;}
    }
}
