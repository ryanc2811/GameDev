using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    class AI
    {
        //DECLARE a bool for checking when a state should be switched, call it switchState.
        private bool switchState = false;
        // DECLARE a float for storing the current time, call it timer.
        private float Timer;
        //DECLARE an int for counting how many seconds have passed, call it Seconds.
        private int Seconds=0;
        //property for stateMachine of type AI.
        public StateMachine<AI> stateMachine { get; set; }
        //property for switch state boolean.
        public bool SwitchState { get => switchState; set => switchState = value; }

        public AI()
        {
            //INSTANTIATE a new StateMachine object and pass a reference to current class
            stateMachine = new StateMachine<AI>(this);
            //alter the current state to the first state
            stateMachine.alterState(new FirstState());
            //set the timer to the current time
            Timer = DateTime.Now.Second;
            
        }
        public void Update(DateTime gameTime)
        {
            //checks if a second has passed
            if (DateTime.Now.Second> Timer + 1)
            {
                //set the timer to the current time
                Timer = DateTime.Now.Second;
                //Add one to the seconds counter
                Seconds++;
                Console.WriteLine(Seconds);
            }
            //if 3 seconds have passed then
            if (Seconds == 3)
            {
                //set second counter to 0
                Seconds = 0;
                //set switch state variable to its opposite value
                SwitchState =!SwitchState;
            }
            
             //call stateMachines update function
             stateMachine.Update();
            
        }
    }
}
