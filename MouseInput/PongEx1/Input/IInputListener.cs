using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Input
{
    public interface IInputListener
    {
        void OnNewInput(object sender, InputEventArgs args);
        
    }
}
