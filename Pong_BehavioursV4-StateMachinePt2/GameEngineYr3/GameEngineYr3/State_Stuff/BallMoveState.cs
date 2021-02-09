using GameEngine.BehaviourManagement;
using GameEngine.Commands;
using Pong.Commands;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Animation_Stuff;
using GameEngine.Input;
using GameEngine.BehaviourManagement.StateMachine_Stuff;

namespace Pong.State_Stuff
{
    class BallMoveState : IState
    {
        ICommandManager commandManager;
        ICommand currentCommand;
        IAnimationManager animationManager;
        Vector2 moveDirection;
        public BallMoveState(IAnimationManager pAnimationManager)
        {
            animationManager = pAnimationManager;
        }
        public void AddCommandManager(ICommandManager pCommandManager)
        {
            commandManager = pCommandManager;
        }

        public void Begin()
        {
            moveDirection= ((MoveCommand)currentCommand).direction;
            if (moveDirection.Y > 0)
                animationManager.Play("moveUp");
            else
                animationManager.Play("moveDown");
        }

        public void ChangeCommand(ICommand pNewCommand)
        {
            currentCommand = pNewCommand;
        }
        public void Execute()
        {
            commandManager.ExecuteCommand(currentCommand);
        }

        public void End()
        {
            animationManager.Stop();
        }

        public int HandleInput(IAIComponent AI, InputEventArgs inputEvent)
        {
            throw new NotImplementedException();
        }

        public int StateIndex()
        {
            throw new NotImplementedException();
        }

        public void InitState(IStateMachine stateMachine)
        {
            throw new NotImplementedException();
        }
    }
}
