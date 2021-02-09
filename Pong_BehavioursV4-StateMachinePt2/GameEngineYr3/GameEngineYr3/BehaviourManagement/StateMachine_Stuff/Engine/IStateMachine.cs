using GameEngine.Animation_Stuff;
using GameEngine.Commands;
using GameEngine.Entities;
using GameEngine.Input;
using GameEngine.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateMachine
    {
        /// <summary>
        /// Initiate a new State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="command"></param>
        void ChangeState(int newStateIndex);



        /// <summary>
        /// Adds a new state to the dictionairy
        /// </summary>
        /// <param name="pStateEnum"></param>
        /// <param name="pState"></param>
        


        /// <summary>
        /// Removes a state from the dictionairy
        /// </summary>
        /// <param name="pStateEnum"></param>
        void RemoveState(int stateIndex);
        /// <summary>
        /// Updates the current state
        /// </summary>
        void Update();
        void PreviousState();
    }
}
