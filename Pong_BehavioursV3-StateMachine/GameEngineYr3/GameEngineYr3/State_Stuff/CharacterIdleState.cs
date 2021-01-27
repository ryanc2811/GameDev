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
    class CharacterIdleState:IState
    {
        ICommandManager commandManager;
        ICommand currentCommand;
        IAnimationManager animationManager;
        public CharacterIdleState(IAnimationManager pAnimationManager)
        {
            animationManager = pAnimationManager;
        }
        public void AddCommandManager(ICommandManager pCommandManager)
        {
            commandManager = pCommandManager;
        }

        public void Begin()
        {
            Console.WriteLine("IDLE");
            //animationManager.Play("idle");
            
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
