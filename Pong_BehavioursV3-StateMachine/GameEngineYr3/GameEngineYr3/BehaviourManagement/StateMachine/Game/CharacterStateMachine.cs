using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.State_Stuff
{
    class CharacterStateMachine:StateMachine<CharacterStateMachine>
    {
        public enum CharacterState
        {
            Idle,
            Move,
            Jump
        }

        public CharacterState currentState;

        public CharacterStateMachine(IAnimationManager animationManager)
        {
            Console.WriteLine("HI");
            AnimationManager = animationManager;
            OnStateChanged += CharacterStateMachine_OnStateChanged;
            PopulateStateMachine();
        }

        private void CharacterStateMachine_OnStateChanged(int pStateIndex) => currentState = (CharacterState)pStateIndex;

        protected override void PopulateStateMachine()
        {
            AllStates = new Dictionary<int, BaseState<CharacterStateMachine>>()
            {
                {(int)CharacterState.Idle,new CharacterIdleState()},
                {(int)CharacterState.Move,new CharacterMoveState()}
            };
        }
    }
}
