using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
   public interface IInput
    {
        //Update 
        void Update();
        //Add Event Arguments to the array
        void AddEventHandler(EventHandler<InputEventArgs> handler);
        //Remove Event Arguments from the array 
        void RemoveEventHandler(EventHandler<InputEventArgs> handler);
    }
}
