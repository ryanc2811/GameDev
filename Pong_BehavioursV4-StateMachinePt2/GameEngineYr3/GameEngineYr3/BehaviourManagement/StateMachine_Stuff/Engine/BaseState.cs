using GameEngine.Commands;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public abstract class BaseState:IState
    {

        protected BaseCommand[] commands;

        protected IStateMachine stateMachine;
        public  void InitState(IStateMachine stateMachine)
        {
            SetCommands();
            SetOwner(stateMachine);
        }

        private void SetOwner(IStateMachine pStateMachine)
        {
            stateMachine = pStateMachine;

            foreach(BaseCommand command in commands)
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
