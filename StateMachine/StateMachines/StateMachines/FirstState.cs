using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    class FirstState:State<AI>
    {
        public static FirstState instance;
        public FirstState()
        {
            if (instance != null)
            {
                return;
            }
            
            instance = this;

        }
        public static FirstState stateInstance
        {
            get { 
            if (instance == null)
            {
                new FirstState();
            }

            return instance;
            }
        }
        public override void enterState(AI stateOwner)
        {
            Console.WriteLine("Starting First State Now...");
        }

        public override void exitState(AI stateOwner)
        {
            Console.WriteLine("Finishing First State Now...");
        }

        public override void updateState(AI stateOwner)
        {
            if (stateOwner.SwitchState)
            {
                stateOwner.stateMachine.alterState(SecondState.stateInstance);
            }
        }
    }
}
