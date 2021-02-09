using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine;
using GameEngine.Commands;
using GameEngine.Entities;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pong.State_Stuff
{
    class CharacterIdleState:BaseState<CharacterStateMachine>, IStateWithAnimation,IStateWithInput
    {
        ICommandManager commandManager;
        ICommand currentCommand;
        //IAnimationManager animationManager;
        public CharacterIdleState()
        {
        }

        public override void Begin()
        {
            stateMachine.AnimationManager.Play("idle");
        }
        public override void End()
        {
            //throw new NotImplementedException();
        }

        public override void Execute()
        {
            
        }

        public int HandleInput(IAIUser entity, InputEventArgs inputEvent)
        {
            //stateMachine.AnimationManager.Play("idle");
            if (inputEvent.PressedKeys.Contains(Keys.W)||inputEvent.PressedKeys.Contains(Keys.S)||inputEvent.PressedKeys.Contains(Keys.D)||inputEvent.PressedKeys.Contains(Keys.A))
                return (int)CharacterStateMachine.CharacterState.Move;
            return StateIndex();
        }
        public void SetAnimator(IAnimationManager pAnimationManager)
        {
            //animationManager = pAnimationManager;
        }

        public override void SetCommands()
        {
            commands = new BaseCommand<CharacterStateMachine>[]
            {
                new CharacterIdleCommand(),
            };
        }

        public override int StateIndex()
        {
            return (int)CharacterStateMachine.CharacterState.Idle;
        }
    }
}
