using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.Commands;
using Microsoft.Xna.Framework;
using Pong.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.State_Stuff
{
    class CharacterMoveState: IState
    {
        ICommandManager commandManager;
        ICommand currentCommand;
        IAnimationManager animationManager;
        Vector2 moveDirection;
        public CharacterMoveState(IAnimationManager pAnimationManager)
        {
            animationManager = pAnimationManager;
        }
        public void AddCommandManager(ICommandManager pCommandManager)
        {
            commandManager = pCommandManager;
        }

        public void Begin()
        {
            moveDirection = ((MoveCommand)currentCommand).direction;
            
            if (moveDirection.Y < 0)
                animationManager.Play("moveUp");
            else if(moveDirection.Y > 0)
                animationManager.Play("moveDown");
            else if (moveDirection.X > 0)
                animationManager.Play("moveRight");
            else if (moveDirection.X < 0)
                animationManager.Play("moveLeft");

            Console.WriteLine("MOVING");
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
    }
}
