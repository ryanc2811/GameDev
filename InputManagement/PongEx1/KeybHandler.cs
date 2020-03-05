using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    public class KeybHandler : IKeyboardInput
    {
        private Keys[] pressedKeys;
        //private IList<Keys> pressedKeys = new List<Keys>();
        public event EventHandler<InputEventArgs> InputEvent;
        KeyboardState keyboardState;
        public KeybHandler()
        {
            
        }
        public void Update()
        {

            keyboardState = Keyboard.GetState();
            pressedKeys=keyboardState.GetPressedKeys();
            
            
            if (pressedKeys != null)
            {

                //for (int i = 0; i < pressedKeys.Count; i++)
                //{
                //    if (keyboardState.IsKeyUp(Keys.W))
                //    {
                //        if (pressedKeys[i] == Keys.W)
                //            pressedKeys.RemoveAt(i);
                //    }

                //    if (keyboardState.IsKeyUp(Keys.S))
                //    {
                //        if (pressedKeys[i] == Keys.S)
                //            pressedKeys.RemoveAt(i);

                //    }

                //}
                OnEvent(pressedKeys);
            }
        }

        public virtual void OnEvent(Keys[] pressedKeys)
        {
            List<Keys>pressedKeysList = pressedKeys.ToList();
            if (InputEvent != null)
            {
               
                IList<Keys> pressedEventKeys = new List<Keys>();
                for (int i = 0; i < pressedKeysList.Count; i++)
                {
                    pressedEventKeys.Add(pressedKeys[i]);
                    
                }

                if (pressedEventKeys.Count > 0)
                {

                    InputEventArgs eventData = new InputEventArgs();
                    eventData.PressedKeys = pressedKeys;
                    InputEvent(this, eventData);
                }
            }
        }

        public void AddEventHandler(EventHandler<InputEventArgs> handler)
        {
            InputEvent += handler;
        }
    }
}
