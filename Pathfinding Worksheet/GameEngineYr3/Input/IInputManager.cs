using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    interface IInputManager
    {
        //Add Listener to the list
        void addEventListener(InputDevice inputDevice, EventHandler<InputEventArgs> handler);
        //remove Listener from the List
        void removeEventListener(InputDevice inputDevice,EventHandler<InputEventArgs> handler);
        //Update
        void Update();
    }
}
