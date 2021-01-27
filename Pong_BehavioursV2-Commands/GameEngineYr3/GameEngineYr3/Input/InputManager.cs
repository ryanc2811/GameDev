
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    //This is the publisher class
    class InputManager :IInputManager
    {
        #region Variables
        //DECLARE Dictionary 
        private Dictionary<InputDevice, IInput> dictInput;
        #endregion

        #region Constructor
        public InputManager()
        {  
            //CREATE Dictionary
            dictInput = new Dictionary<InputDevice, IInput>();
            //Add Keyboard to the dictionary
            dictInput.Add(InputDevice.Keyboard, new KeybHandler() as IInput);
            //Add Mouse to the Dictionary
            dictInput.Add(InputDevice.Mouse, new MouseHandler() as IInput);
        }
        #endregion

        #region Update
        public void Update()
        {
            foreach (InputDevice input in Enum.GetValues(typeof(InputDevice)))
            {
                dictInput[input].Update();
            }
         
        }
        #endregion

        #region Add / Remove Device / Listener
        //Add Device to the array
        public void addEventListener(InputDevice inputType, EventHandler<InputEventArgs> handler)
        { 
            dictInput[inputType].AddEventHandler(handler);

        }
        //REmove device from the array
        public void removeEventListener(InputDevice inputType,EventHandler<InputEventArgs> handler)
        {
            dictInput[inputType].RemoveEventHandler(handler);
        }
        #endregion
    }
}
