using GameEngine.BehaviourManagement.StateMachine_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected IStateMachine owner;
        public void SetOwner(IStateMachine pOwner) => owner=pOwner;
        public abstract void Execute();
        public abstract void Undo();

        public abstract void StartCommand();

        public abstract void ExitCommand();
    }
}
