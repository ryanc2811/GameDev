using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine_Stuff;
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
    class CharacterMoveState: BaseState, IStateWithAnimation, IStateWithInput
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
            commands = new BaseCommand[]
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

        public int HandleInput(object sender, InputEventArgs inputEvent)
        {
            //animationManager = ((IAnimatedSprite)AI.GetAIUser()).GetAnimationManager();

            Vector2 velocity = Vector2.Zero;
            float speed = 2f;
            if (inputEvent.PressedKeys.Contains(Keys.W))
            {
                ((IAnimatedSprite)((IAIComponent)stateMachine).GetAIUser()).GetAnimationManager().Play("moveUp");
                velocity.Y -= speed;
            }
                
            else if (inputEvent.PressedKeys.Contains(Keys.S))
            {
                ((IAnimatedSprite)((IAIComponent)stateMachine).GetAIUser()).GetAnimationManager().Play("moveDown");
                velocity.Y += speed;
            }
            else if (inputEvent.PressedKeys.Contains(Keys.D))
            {
                ((IAnimatedSprite)((IAIComponent)stateMachine).GetAIUser()).GetAnimationManager().Play("moveRight");
                velocity.X += speed;
            }
            else if (inputEvent.PressedKeys.Contains(Keys.A))
            {
                ((IAnimatedSprite)((IAIComponent)stateMachine).GetAIUser()).GetAnimationManager().Play("moveLeft");
                velocity.X -= speed;
            }
            else
            {
                return (int)CharacterStateMachine.CharacterState.Idle;
            }
            ((IAIComponent)stateMachine).GetAIUser().SetVelocity(velocity.X, velocity.Y);
            return StateIndex();
        }

        public void SetAnimator(IAnimationManager pAnimationManager)
        {
            //animationManager = pAnimationManager;
            Console.WriteLine("AFAfaf");
        }

    }
}
