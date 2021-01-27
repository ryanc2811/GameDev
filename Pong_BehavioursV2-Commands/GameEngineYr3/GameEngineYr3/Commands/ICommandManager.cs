using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Commands
{
    public interface ICommandManager
    {
        void ExecuteCommand(ICommand pCommand);
        void Undo();
        void Redo();
    }
}
