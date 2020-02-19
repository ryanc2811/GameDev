using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    class SecondState : State<AI>
    { 
        private static SecondState instance;
        public SecondState()
        {
            //the static instance of second state is not null, then return
            if (instance != null)
            {
                return;
            }
             //set the static instanc of second state to this instance
             instance = this;
           
        }
        //property for state instance  
        public static SecondState stateInstance
        {
            get{
                //if the instance is set to null then create a new intance of second state
            if (instance == null)
            {
                new SecondState();
            }
            //return the instance variable
            return instance;
            }
        }
        //method for entering the state
        public override void enterState(AI stateOwner)
        {
            Console.WriteLine("Starting Second State Now...");
        }
        //methods for exiting the state
        public override void exitState(AI stateOwner)
        {
            Console.WriteLine("Finishing Second State Now...");
        }
        //method for updating the state
        public override void updateState(AI stateOwner)
        {
            //if the switch state variable is set to false, then change the current state to the first state
            if (!stateOwner.SwitchState)
            {
                stateOwner.stateMachine.alterState(FirstState.stateInstance);
            }
        }
    }
}
