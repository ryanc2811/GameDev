using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine;
using GameEngine.Commands;
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
    class CharacterMoveState: BaseState<CharacterStateMachine>, IStateWithAnimation, IStateWithInput
    {
        ICommandManager commandManager;
        ICommand currentCommand;
        //IAnimationManager animationManager;

        //private CharacterState state = CharacterState.Move;

        Vector2 moveDirection;
        public CharacterMoveState()
        {

        }

        public override void SetCommands()
        {
            commands = new BaseCommand<CharacterStateMachine>[]
            {
                new CharacterMoveCommand(),
            };
        }
        public override void Begin()
        {
            //moveDirection = ((MoveCommand)currentCommand).direction;
            
        }

        public override void End()
        {
            //throw new NotImplementedException();
        }

        public override void Execute()
        {
            //throw new NotImplementedException();
        }

        public override int StateIndex()
        {
            return (int)CharacterStateMachine.CharacterState.Move;
        }

        public int HandleInput(IAIComponent AI, InputEventArgs inputEvent)
        {
            //animationManager = ((IAnimatedSprite)AI.GetAIUser()).GetAnimationManager();
            if(inputEvent.PressedKeys.Contains(Keys.W))
                stateMachine.AnimationManager.Play("moveUp");
            else if (inputEvent.PressedKeys.Contains(Keys.S))
                stateMachine.AnimationManager.Play("moveDown");
            else if (inputEvent.PressedKeys.Contains(Keys.D))
                stateMachine.AnimationManager.Play("moveRight");
            else if (inputEvent.PressedKeys.Contains(Keys.A))
                stateMachine.AnimationManager.Play("moveLeft");
            else
            {
                return (int)CharacterStateMachine.CharacterState.Idle;
            }

            return StateIndex();
        }

        public void SetAnimator(IAnimationManager pAnimationManager)
        {
            //animationManager = pAnimationManager;
            Console.WriteLine("AFAfaf");
        }

    }
}
