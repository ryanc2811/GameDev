using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Input
{
   public interface IInput
    {
        void Update();
        void AddEventHandler(EventHandler<InputEventArgs> handler);
        void RemoveEventHandler(EventHandler<InputEventArgs> handler);
    }
}
