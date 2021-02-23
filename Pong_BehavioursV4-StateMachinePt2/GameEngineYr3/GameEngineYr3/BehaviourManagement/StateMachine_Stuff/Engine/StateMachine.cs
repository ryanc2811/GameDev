using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    /// <summary>
    /// The mind of the AI component
    /// </summary>
    class StateMachine: AIComponent,IStateMachine
    {
        //DECLARE an IDictionary for storing references to each state within the state machine
        private IDictionary<int, IState> allStates = new Dictionary<int, IState>();
        //DECLARE an ITextEntity for storing a reference to the text object that displays the current state
        protected ITextEntity stateText;
        //DECLARE an IState for storing a reference to the current state
        protected IState currentState;
        //DECLARE an IAIUser for storing a reference to the AIUser that relates to the the statemachine
        protected IAIUser gameObject;
        //DECLARE an Action for storing an event that is triggered when the state changes
        protected event Action<int> OnStateChanged = delegate { };
        //DECLARE an integer for storing the index of the current state
        protected int currentStateIndex;
        //DECLARE an IDictionary for returning the states dictionary
        public IDictionary<int, IState> AllStates => allStates;
        //DECLARE an int for returning the current state index
        public int CurrentStateIndex => currentStateIndex;

        /// <summary>
        /// Initialises the statemachine
        /// </summary>
        /// <param name="pState"></param>
        public void InitialiseStateMachine(IState pState= null)
        {
            //Set the current state index to the index of the first value in the dictionary
            currentStateIndex = AllStates.First().Value.StateIndex();
            //Set the current state to the first value in the dictionary
            currentState = pState ?? AllStates.Values.First();
            
            foreach(KeyValuePair<int,IState> entry in AllStates)
            {
                //INITIALISE STATE
                entry.Value.InitState(this, gameObject);
            }
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
        /// Update the state
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            if (currentState != null)
                currentState.Execute(gameTime);
        }

       /// <summary>
       /// Sets the local AIUser
       /// </summary>
       /// <param name="aiUser"></param>
        #region AIComponent
        public override void SetAIUser(IAIUser aiUser)
        {
            gameObject = aiUser;
        }
        /// <summary>
        /// Initialise StateMachine
        /// </summary>
        public override void Initialise()
        {
            InitialiseStateMachine();
        }
        /// <summary>
        /// Initialises states once content is loaded
        /// </summary>
        public override void OnContentLoad()
        {
            //Start the current state
            currentState.Begin();
        }
        /// <summary>
        /// Returns the IAIUser related to the statemachine
        /// </summary>
        /// <returns></returns>
        public override IAIUser GetAIUser()
        {
            return gameObject;
        }
        /// <summary>
        /// Adds a state to the dictionary
        /// </summary>
        /// <param name="pStateIndex"></param>
        /// <param name="pState"></param>
        public void AddState(int pStateIndex, IState pState) 
        {
            allStates.Add(pStateIndex, pState);
        }
        /// <summary>
        /// Adds the text entity to the state machine
        /// </summary>
        /// <param name="textEntity"></param>
        public void AddStateText(ITextEntity textEntity)
        {
            stateText = textEntity;
        }
        /// <summary>
        /// Updates the state text once the current state is changed
        /// </summary>
        /// <param name="pStateIndex"></param>
        protected virtual void UpdateStateText(int pStateIndex)
        {
        }
        #endregion
    }
}
