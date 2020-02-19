using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    class InputManager :IInputManager
    {
        private Dictionary<InputDevice,IInput> dictInput;

        public InputManager()
        {
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
        }

        protected virtual void OnNewInput(string newArg)
        {
            myEventArgs args = new myEventArgs(newArg);
            NewInput(this, args);
        }
        public void addEventListener(InputDevice inputDevice, EventHandler<myEventArgs> handler)
        {
            NewInput += handler;
        }
        public event EventHandler<myEventArgs> NewInput;

        public void removeEventLister(EventHandler<myEventArgs> handler)
        {
            
        }
    }
}
