using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.State_Conditions;
using GameEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GameEngine.Transitions
{
    public interface ITransition
    {
        /// <summary>
        /// Execute transition
        /// </summary>
        int ExecuteTransition(GameTime gameTime);
        /// <summary>
        /// Gets the reference to the condition object
        /// </summary>
        ICondition Condition { get; }
        /// <summary>
        /// Starts the transition
        /// </summary>
        void StartTransition();
        /// <summary>
        /// Closes the transition
        /// </summary>
        void ExitTransition();
        /// <summary>
        /// passes the AIUser to condition
        /// </summary>
        /// <param name="owner"></param>
        void SetOwner(IAIUser owner);
    }
}
