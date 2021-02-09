using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.State_Stuff
{
    class CharacterStateMachine:StateMachine
    {
        public enum CharacterState
        {
            Idle,
            Move,
            Jump
        }

        public CharacterState currentState;

        public CharacterStateMachine(/*IAnimationManager animationManager*/)
        {
            Console.WriteLine("HI");
            //AnimationManager = animationManager;
            OnStateChanged += CharacterStateMachine_OnStateChanged;
            PopulateStateMachine();
        }

        private void CharacterStateMachine_OnStateChanged(int pStateIndex) => currentState = (CharacterState)pStateIndex;

        protected override void PopulateStateMachine()
        {
            AllStates = new Dictionary<int, IState>()
            {
                {(int)CharacterState.Idle,new CharacterIdleState()},
                {(int)CharacterState.Move,new CharacterMoveState()}
            };
        }
        //Add state method 
        //Pass key as int
        //State machine becomes an ai component
        //AI component manager has factory method for statemachine
        //(perhaps if i have more time) states are created with factory method
        //animation manager being pass through constructor is a big no no (either do it through a method or pass it into a command that needs it)
        //Entity creates the commands and passes it to states
    }
}
