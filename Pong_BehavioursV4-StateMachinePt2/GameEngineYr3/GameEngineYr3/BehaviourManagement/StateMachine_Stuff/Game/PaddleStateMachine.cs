using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.Collision;
using GameEngine.Entities;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.State_Stuff
{
    class PaddleStateMachine : StateMachine, ICollidable, IInputListener
    {
        /// <summary>
        /// Initialises the statemachine
        /// </summary>
        public override void Initialise()
        {
            base.Initialise();
            OnStateChanged += CharacterStateMachine_OnStateChanged;
            OnStateChanged += UpdateStateText;
        }
        /// <summary>
        /// Sets the current state index once state has changed
        /// </summary>
        /// <param name="pStateIndex"></param>
        private void CharacterStateMachine_OnStateChanged(int pStateIndex) => currentStateIndex = pStateIndex;

        /// <summary>
        /// Returns the hitbox of the AI
        /// </summary>
        /// <returns></returns>
        #region ICollidable
        public Rectangle GetHitBox()
        {
            return ((IStateWithCollision)currentState).GetHitBox();
        }
        /// <summary>
        /// Handles the collision
        /// </summary>
        /// <param name="entity"></param>
        public void OnCollide(IAIComponent entity)
        {
            ((IStateWithCollision)currentState).HandleCollision(entity);
        }
        #endregion
        /// <summary>
        /// Updates the state text entity
        /// </summary>
        /// <param name="pStateIndex"></param>
        protected override void UpdateStateText(int pStateIndex)
        {
           stateText.Text = "Paddle: "+((PaddleState)pStateIndex).ToString();
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            ((IStateWithInput)currentState).HandleInput(sender,args);
        }
    }
}
