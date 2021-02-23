using GameEngine.Collision;
using GameEngine.Commands;
using GameEngine.Entities;
using GameEngine.Input;
using GameEngine.Transitions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public abstract class BaseState:IState
    {
        //DECLARE an ICommand[] for storing a collection of command that relate to the current state
        protected ICommand[] commands;
        //DECLARE an ITransition[] for storing a collection of transtions that relate to the current state
        protected ITransition[] transitions;
        //DECLARE an IStatemachine for storing a reference to the state's statemachine
        protected IStateMachine stateMachine;
        protected IAIUser owner;
        /// <summary>
        /// Initialises the state
        /// </summary>
        /// <param name="pStateMachine"></param>
        /// <param name="owner"></param>
        public void InitState(IStateMachine pStateMachine, IAIUser owner)
        {
            //Set the statemachine member
            stateMachine = pStateMachine;
            //Populate the commands array
            SetCommands();
            //Populate the transitions array
            SetTransitions();
            //Pass reference to IAIUser to transitions and commands
            SetOwner(owner);
            //If the state uses input, then subscribe all the transitions and commands to input event
            if(this is IStateWithInput)
                SubscribeInputListeners();
            if (this is IStateWithCollision)
                SubscribeCollisionListeners();
        }

        private void SubscribeCollisionListeners()
        {
            foreach (ITransition transition in transitions)
            {
                //If the condition in transition uses collision, then subscribe the method to the collision event
                if (transition.Condition is ICollidable)
                    ((IStateWithCollision)this).CollisionEvent += ((ICollidable)transition.Condition).OnCollide;
            }
            foreach (ICommand command in commands)
            {
                //if the command uses collision, then subscribe the method to the input event
                if (command is ICollidable)
                    ((IStateWithCollision)this).CollisionEvent += ((ICollidable)command).OnCollide;
            }
        }

        /// <summary>
        /// Subscribes all input listeners in transitions and commands to input event
        /// </summary>
        private void SubscribeInputListeners()
        {
            foreach (ITransition transition in transitions)
            {
                //If the condition in transition uses input, then subscribe the method to the input event
                if (transition.Condition is IInputListener)
                    ((IStateWithInput)this).InputEvent += ((IInputListener)transition.Condition).OnNewInput;
            }
            foreach (ICommand command in commands)
            {
                //if the command uses input, then subscribe the method to the input event
                if (command is IInputListener)
                    ((IStateWithInput)this).InputEvent += ((IInputListener)command).OnNewInput;
            }
        }
        /// <summary>
        /// passes the IAIuser to commands and transitions
        /// </summary>
        /// <param name="pOwner"></param>
        private void SetOwner(IAIUser pOwner)
        {
            owner = pOwner;
            foreach(ICommand command in commands)
            {
                command.SetOwner(pOwner);
            }
            foreach (ITransition transition in transitions)
            {
                transition.SetOwner(pOwner);
            }
        }
        /// <summary>
        /// Populates the commands array
        /// </summary>
        public abstract void SetCommands();
        /// <summary>
        /// Populates the transitions array
        /// </summary>
        public abstract void SetTransitions();
        /// <summary>
        /// Handles everything once the state has started
        /// </summary>
        public virtual void Begin() 
        {
            foreach (ICommand command in commands)
            {
                command.StartCommand();
            }
            foreach (ITransition transition in transitions)
            {
                transition.StartTransition();
            }
        }
        /// <summary>
        /// Handles everything once the state has ended
        /// </summary>
        public virtual void End() 
        {
            foreach (ICommand command in commands)
            {
                command.ExitCommand();
            }
            foreach (ITransition transition in transitions)
            {
                transition.ExitTransition();
            }
        }
        /// <summary>
        /// Executes the state behaviours
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Execute(GameTime gameTime)
        {
            int state = -1;
            
            //Execute commands
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
            //Execute Transitions
            foreach (ITransition transition in transitions)
            {
                state =transition.ExecuteTransition(gameTime);
            }
            //Change state once the state is different to current state index
            if (state != stateMachine.CurrentStateIndex)
            {
                stateMachine.ChangeState(state);
            }
        }
        /// <summary>
        /// Return the current state index
        /// </summary>
        /// <returns></returns>
        public abstract int StateIndex();
    }
}
