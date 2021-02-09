using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public class InputEventArgs : EventArgs
    {
        //DECLARE Array List of keys pressed
        private IList<Keys> pressedKeys;
        private IList<Keys> keysUp;
        //DECLARE variable to store mouse position
        private Vector2 mousePos;
        //DECLARE boolean to check if left button was used
        private bool leftClicked;
        //DECLARE boolean to check if right button was used
        private bool rightClicked;
        #region Getters and Setters
        public Vector2 MousePos { get { return mousePos; } set { mousePos = value; } }
        public bool LeftClicked { get { return leftClicked; } set { leftClicked = value; } }
        public bool RightClicked { get { return rightClicked; } set { rightClicked = value; } }
        public IList<Keys> PressedKeys { get { return pressedKeys; } set{pressedKeys=value;} }
        public IList<Keys> KeysUp { get { return keysUp; } set { keysUp = value; } }
        #endregion

    }
}
