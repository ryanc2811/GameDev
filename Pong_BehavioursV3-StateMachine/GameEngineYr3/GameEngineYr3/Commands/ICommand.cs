using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    public interface ICommand
    {
        /// <summary>
        /// Execute command
        /// </summary>
        void Execute();
        /// <summary>
        /// Undo command
        /// </summary>
        void Undo();
    }
}
