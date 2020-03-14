using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Input
{
    public class InputEventArgs : EventArgs
    {
        private IList<Keys> pressedKeys;
        private Vector2 mousePos;
        private bool leftClicked;
        private bool rightClicked;
        public Vector2 MousePos { get { return mousePos; } set { mousePos = value; } }
        public bool LeftClicked { get { return leftClicked; } set { leftClicked = value; } }
        public bool RightClicked { get { return rightClicked; } set { rightClicked = value; } }
        public IList<Keys> PressedKeys { get { return pressedKeys; } set{pressedKeys=value;} }
        
       
    }
}
