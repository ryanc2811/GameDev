using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class CommandManager:ICommandManager
    {
        //DECLARE an IList for storing references to the commands
        private IList<ICommand> commands;
        //DECLARE an int for storing the current command index
        private int commandIndex;
        public CommandManager()
        {
            commands = new List<ICommand>();
        }
        /// <summary>
        /// Executes the passed command
        /// </summary>
        /// <param name="pCommand"></param>
        public void ExecuteCommand(ICommand pCommand)
        {
            commands.Add(pCommand);
            
            pCommand.Execute();
            commandIndex = commands.Count - 1;
        }
        /// <summary>
        /// Undo the last command
        /// </summary>
        public void Undo()
        {
            if (commandIndex < 1)
                return;

            commands.RemoveAt(commandIndex);
            commandIndex--;
        }
        /// <summary>
        /// Redo the last command
        /// </summary>
        public void Redo()
        {
            commands[commandIndex].Execute();
            commandIndex++;
        }
    }
}
