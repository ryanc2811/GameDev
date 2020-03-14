using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Input
{
    //This is the publisher class
    class InputManager :IInputManager
    {
        private Dictionary<InputDevice, IInput> dictInput;
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
      
        public void addEventListener(InputDevice inputType, EventHandler<InputEventArgs> handler)
        { 
            dictInput[inputType].AddEventHandler(handler);

        }
        
        public void removeEventListener(InputDevice inputType,EventHandler<InputEventArgs> handler)
        {
            dictInput[inputType].RemoveEventHandler(handler);
        }
    }
}
