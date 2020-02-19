using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    public class StateMachine<T> 
    {
        //property for current state
        public State<T> _State { get; private set; }
        //a generic object for the owner of the state(i.e. an AI object)
        public T stateOwner;
        
        public StateMachine(T pStateOwner)
        {
            //assign the passed pStateOwner variable to the local stateOwner variable
            stateOwner = pStateOwner;
            //set set object to null on construction of stateMachine
            _State = null;
        }

        public void alterState(State<T> newState)
        {
            //if the state object is not null then exit the state
            if (_State!=null)
            {
                _State.exitState(stateOwner);
            }
            //set the current state to the passed value
            _State = newState;
            //enter the new state
            _State.enterState(stateOwner);

        }
        public void Update()
        {
            //if the state object does not equal to null then call update from the current state class
            if (_State != null)
            {
                _State.updateState(stateOwner);
            }
        }
    }
}
