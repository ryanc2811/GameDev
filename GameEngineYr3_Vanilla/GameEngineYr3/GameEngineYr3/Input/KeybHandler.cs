using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Input
{
    public class KeybHandler : IKeyboardInput
    {
        #region Variables
        //DECLARE Arrray to hold keys pressed
        private Keys[] pressedKeys;
        //DECLARE EvenHandler
        public event EventHandler<InputEventArgs> InputEvent;
        //DECLARE Keyboard state
        KeyboardState keyboardState;
        #endregion

        #region Constructor
        public KeybHandler()
        {
            //do Nothing
        }
        #endregion

        #region Update
        public void Update()
        {
            //Get KeyBoard State
            keyboardState = Keyboard.GetState();
            //Get Keys Pressed
            pressedKeys=keyboardState.GetPressedKeys();
            
            //if There is some keys pressed do something
            if (pressedKeys != null)
            {
                OnEvent(pressedKeys);
            }
        }
        #endregion

        #region OnEvent
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
        #endregion

        #region Add/Remove Event Handler
        public void AddEventHandler(EventHandler<InputEventArgs> handler)
        {
            InputEvent += handler;
        }
        public void RemoveEventHandler(EventHandler<InputEventArgs> handler)
        {
            InputEvent -= handler;
        }
        #endregion
    }
}
