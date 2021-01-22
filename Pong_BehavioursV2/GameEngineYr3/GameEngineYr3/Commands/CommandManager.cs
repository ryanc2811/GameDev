using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Commands
{
    class CommandManager:ICommandManager
    {
        private IList<ICommand> commands;

        private int commandIndex;
        public CommandManager()
        {
            commands = new List<ICommand>();
        }

        public void ExecuteCommand(ICommand pCommand)
        {
            commands.Add(pCommand);
            
            pCommand.Execute();
            commandIndex = commands.Count - 1;
        }

        public void Undo()
        {
            if (commandIndex < 1)
                return;

            commands[commandIndex].Undo();
            commands.RemoveAt(commandIndex);
            commandIndex--;
        }

        public void Redo()
        {
            commands[commandIndex].Execute();
            commandIndex++;
        }
    }
}
