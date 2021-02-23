using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.State_Conditions;
using GameEngine.Entities;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameEngine.Transitions
{
    /// <summary>
    /// Transitions to a new state when a condition returns true
    /// </summary>
    class Transition : ITransition
    {
        //DECLARE an ICondition for storing the condition of the transition
        private ICondition condition;
        //DECLARE an int for storing the key of the transition state
        private int transitionState;
        //DECLARE an int for storing the key of the current state
        private int currentState;
        //DECLARE a double for storing the delay of the transition
        private double delay = 0f;
        //DECLARE a TimeSpan for storing the time span of the delay
        private TimeSpan interval;
        //DECLARE a TimeSpan for storing the elapsed time
        private TimeSpan elapsed;
        //DECLARE a string for storing the name of the transition
        private string transitionName;

        /// <summary>
        /// Intitialises all the members
        /// </summary>
        /// <param name="pName"></param>
        /// <param name="pCondition"></param>
        /// <param name="pTransitionState"></param>
        /// <param name="pCurrentState"></param>
        /// <param name="pDelay"></param>
        public Transition(string pName,ICondition pCondition, int pTransitionState, int pCurrentState, double pDelay)
        {
            transitionName = pName;
            condition = pCondition;
            transitionState = pTransitionState;
            currentState = pCurrentState;
            delay = pDelay;
        }

        //returns the condition
        public ICondition Condition => condition;

        /// <summary>
        /// Execute the transition depending on the outcome of the condition
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>The next state to transition to</returns>
        public int ExecuteTransition(GameTime gameTime)
        {
            //if the condition is true
            if (condition.FindOutcome())
            {
                //if the delay is less than or equal to 0, then return the transition state straight away
                if (delay <= 0)
                    return transitionState;
                
                return FinishTransition(gameTime.ElapsedGameTime);
            }
            else
                return currentState;
        }
        /// <summary>
        /// Starts the delay of the transition
        /// </summary>
        /// <param name="elapsedGameTime"></param>
        /// <returns>the transition state once the delay has be enacted</returns>
        private int FinishTransition(TimeSpan elapsedGameTime)
        {
            elapsed = elapsed.Add(elapsedGameTime);

            if (elapsed.TotalMilliseconds >= interval.TotalMilliseconds)
                return transitionState;

            return currentState;
        }
        /// <summary>
        /// Close the transition and the condition
        /// </summary>
        public void ExitTransition()
        {
            condition.ExitCondition();
        }
        /// <summary>
        /// Passes the AIUser to the condition
        /// </summary>
        /// <param name="owner"></param>
        public void SetOwner(IAIUser owner)
        {
            condition.SetOwner(owner);
        }
        /// <summary>
        /// Starts the transition and condition
        /// </summary>
        public void StartTransition()
        {
            condition.StartCondition();
            elapsed = TimeSpan.Zero;
            interval = TimeSpan.FromSeconds(delay);
        }
    }
}
