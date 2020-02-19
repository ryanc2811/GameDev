using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachines
{
    //abstract class for a state
    public abstract class State<T>
    {
        //function that is called when a state has first been entered into
        public abstract void enterState(T stateOwner);
        //function that is called when a state is finished
        public abstract void exitState(T stateOwner);
        //fucnction that updates the state 
        public abstract void updateState(T stateOwner);
        
    }
}
