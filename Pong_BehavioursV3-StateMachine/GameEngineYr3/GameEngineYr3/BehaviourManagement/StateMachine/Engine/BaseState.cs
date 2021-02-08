using GameEngine.Commands;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine
{
    public abstract class BaseState<T>:IState where T :StateMachine<T>
    {

        protected BaseCommand<T>[] commands;

        protected T stateMachine;
        public  void InitState(T stateMachine)
        {
            SetCommands();
            SetOwner(stateMachine);
        }

        private void SetOwner(T pStateMachine)
        {
            stateMachine = pStateMachine;

            foreach(BaseCommand<T> command in commands)
            {
                command.SetOwner(stateMachine);
            }
        }

        public abstract void SetCommands();

        public abstract void Begin();

        public abstract void End();

        public abstract void Execute();
        

        public abstract int StateIndex();


    }
}
