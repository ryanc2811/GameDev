using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    public class InputEventArgs : EventArgs
    {
        private IList<Keys> pressedKeys;

        public IList<Keys> PressedKeys { get { return pressedKeys; } set{pressedKeys=value;} }
        
       
    }
}
