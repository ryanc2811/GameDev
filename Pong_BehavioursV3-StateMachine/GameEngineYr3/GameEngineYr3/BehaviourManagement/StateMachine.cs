using GameEngine.Commands;
using GameEngine.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    class StateMachine : IStateMachine
    {
        //DECLARE an IDictionary for storing references to each state within the state machine
        private IDictionary<States, IState> states;
        //DECLARE an IState for storing a reference to the current state
        private IState currentState;
        //DECLARE an ICommandManager for storing a reference to the command manager
        private ICommandManager commandManager;
        public StateMachine()
        {
            states = new Dictionary<States, IState>();
            commandManager= new CommandManager();
        }
        /// <summary>
        /// Change the current state to the new passed state 
        /// </summary>
        /// <param name="pStateEnum"></param>
        /// <param name="command"></param>
        public void ChangeState(States pStateEnum, ICommand command)
        {
            //if the state exists within the dictionary
            if (states[pStateEnum] != null)
            {
                //if there is already a current state
                if (currentState != null)
                {
                    //end the state
                    currentState.End();
                }
                IState newState = states[pStateEnum];
                //set the current state to the new passed state
                currentState = newState;
                //Add the command to the state
                currentState.ChangeCommand(command);
                //Start the new state
                currentState.Begin();
            }
        }
        /// <summary>
        /// Add a state to the dictionary
        /// </summary>
        /// <param name="pStateEnum"></param>
        /// <param name="pState"></param>
        public void AddState(States pStateEnum,IState pState)
        {
            states.Add(pStateEnum, pState);
            //add a reference to the command manager to the state
            pState.AddCommandManager(commandManager);
        }
        /// <summary>
        /// Removes a state from the dictionary
        /// </summary>
        /// <param name="pStateEnum"></param>
        public void RemoveState(States pStateEnum)
        {
            if (states[pStateEnum]!=null)
            {
                states.Remove(pStateEnum);
            }
        }
        /// <summary>
        /// Loads a previous state
        /// </summary>
        public void PreviousState()
        {
            //Undo the last command
            commandManager.Undo();
        }
        /// <summary>
        /// Update the state
        /// </summary>
        public void Update()
        {
            if (currentState != null)
                currentState.Execute();
        }
    }
}
