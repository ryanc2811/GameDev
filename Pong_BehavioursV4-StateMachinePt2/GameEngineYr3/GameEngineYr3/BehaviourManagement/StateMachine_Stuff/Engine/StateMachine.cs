using GameEngine.Animation_Stuff;
using GameEngine.Collision;
using GameEngine.Commands;
using GameEngine.Entities;
using GameEngine.Input;
using GameEngine.State_Stuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    class StateMachine: AIComponent,IStateMachine,ICollidable, IInputListener
    {
        //DECLARE an IDictionary for storing references to each state within the state machine
        private IDictionary<int, IState> allStates = new Dictionary<int, IState>();

        public IDictionary<int, IState> AllStates
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

        protected virtual void PopulateStateMachine() { }
        public void InitialiseStateMachine(IState pState= null)
        {
            currentStateIndex = AllStates.First().Value.StateIndex();
            currentState = pState ?? AllStates.Values.First();

            foreach(KeyValuePair<int,IState> entry in AllStates)
            {
                entry.Value.InitState(this);
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
        public override void Update()
        {
            if (currentState != null)
                currentState.Execute();
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            int stateIndex = ((IStateWithInput)currentState).HandleInput(this, args);
            if (stateIndex != currentStateIndex)
            {
                ChangeState(stateIndex);
            }
        }
        #region AIComponent
        public override void SetAIUser(IAIUser aiUser)
        {
            throw new NotImplementedException();
        }

        public override void Initialise()
        {
            throw new NotImplementedException();
        }

        public override Vector2 GetPosition()
        {
            throw new NotImplementedException();
        }

        public override void OnContentLoad()
        {
            throw new NotImplementedException();
        }

        public override int Height()
        {
            throw new NotImplementedException();
        }

        public override int Width()
        {
            throw new NotImplementedException();
        }

        public override IAIUser GetAIUser()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region ICollidable
        public Rectangle GetHitBox()
        {
            throw new NotImplementedException();
        }

        public void OnCollide(IEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
