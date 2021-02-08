using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    public abstract class BaseCommand<T> : ICommand
    {
        protected T owner;
        public void SetOwner(T pOwner) => owner=pOwner;
        public abstract void Execute();
        public abstract void Undo();

        public abstract void StartCommand();

        public abstract void ExitCommand();
    }
}
