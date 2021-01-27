using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    public interface ICommandManager
    {
        /// <summary>
        /// Execute the passed command
        /// </summary>
        /// <param name="pCommand"></param>
        void ExecuteCommand(ICommand pCommand);
        /// <summary>
        /// Undo last command
        /// </summary>
        void Undo();
        /// <summary>
        /// Redo the last command
        /// </summary>
        void Redo();
    }
}
