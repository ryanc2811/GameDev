using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public interface IInputListener
    {
        //On new Input
        void OnNewInput(object sender, InputEventArgs args);
        
    }
}
