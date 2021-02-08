using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement.StateMachine;
using GameEngine.Commands;
using GameEngine.Input;
using GameEngine.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    public abstract class StateMachine<T> : IStateMachine where T : StateMachine<T>
    {
        //DECLARE an IDictionary for storing references to each state within the state machine
        private IDictionary<int, BaseState<T>> allStates = new Dictionary<int, BaseState<T>>();

        public IDictionary<int, BaseState<T>> AllStates
        {
            get => allStates;
            set
            {
                allStates = value;
                InitialiseStateMachine();
            }
        }

        //DECLARE an IState for storing a reference to the current state
        private IState currentState;
        //DECLARE an ICommandManager for storing a reference to the command manager
        private ICommandManager commandManager;

        public IAnimationManager AnimationManager { get; set; }


        protected event Action<int> OnStateChanged = delegate { };

        private int currentStateIndex;
        public int CurrentStateIndex => currentStateIndex;
        public StateMachine()
        {
            
            commandManager= new CommandManager();
        }

        protected abstract void PopulateStateMachine();
        public void InitialiseStateMachine(IState state= null)
        {
            currentStateIndex = AllStates.First().Value.StateIndex();
            currentState = state ?? AllStates.Values.First();

            foreach(KeyValuePair<int,BaseState<T>>keyValuePair in AllStates)
            {
                keyValuePair.Value.InitState(this as T);
            }

            currentState.Begin();
        }

        /// <summary>
        /// Change the current state to the new passed state 
        /// </summary>
        /// <param name="pStateEnum"></param>
        /// <param name="command"></param>
        public void ChangeState(int newStateIndex)
        {
            //if the state exists within the dictionary
            if (allStates[newStateIndex] != null)
            {
                //if there is already a current state
                if (currentState != null)
                {
                    //end the state
                    currentState.End();
                }
                currentStateIndex = newStateIndex;
                IState newState = allStates[newStateIndex];
                //set the current state to the new passed state
                currentState = newState;
                //Start the new state
                currentState.Begin();
                //Invoke State Changed Event
                OnStateChanged(newStateIndex);
            }
        }
        
        /// <summary>
        /// Removes a state from the dictionary
        /// </summary>
        /// <param name="pStateEnum"></param>
        public void RemoveState(int stateIndex)
        {
            if (allStates[stateIndex]!=null)
            {
                allStates.Remove(stateIndex);
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

        public void HandleInput(IAIComponent AI, InputEventArgs inputEvent)
        {
            int stateIndex = ((IStateWithInput)currentState).HandleInput(AI, inputEvent);
            if (stateIndex != currentStateIndex)
            {
                ChangeState(stateIndex);
            }
        }
    }
}
