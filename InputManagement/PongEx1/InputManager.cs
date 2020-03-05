using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    //This is the publisher class
    class InputManager :IInputManager
    {
        private Dictionary<InputDevice, IInput> dictInput;
        //IInput keyboardHandler;
        public InputManager()
        {
            //keyboardHandler = new KeybHandler();

            dictInput = new Dictionary<InputDevice, IInput>();
            dictInput.Add(InputDevice.Keyboard, new KeybHandler() as IInput);
            dictInput.Add(InputDevice.Mouse, new MouseHandler() as IInput);
        }
        public void Update()
        {
            foreach (InputDevice input in Enum.GetValues(typeof(InputDevice)))
            {
                dictInput[input].Update();
            }
            //keyboardHandler.Update();
        }

        public virtual void OnNewInput(IList<Keys> newArg)
        {
            InputEventArgs args = new InputEventArgs();
            args.PressedKeys = newArg;
            NewInput(this, args);
        }
        public void addEventListener(InputDevice inputType, EventHandler<InputEventArgs> handler)
        { 
                //NewInput += handler;
            dictInput[inputType].AddEventHandler(handler);

        }
        public event EventHandler<InputEventArgs> NewInput;

      
        public void removeEventLister(EventHandler<InputEventArgs> handler)
        {
            
        }
    }
}
