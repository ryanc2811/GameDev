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
        //DECLARE Arrray to hold keys pressed
        private IList<Keys> keysUp;
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
            keysUp = new List<Keys>();
            var keys = Enum.GetValues(typeof(Keys));
            foreach (Keys key in keys)
            {
                if (keyboardState.IsKeyUp(key))
                    keysUp.Add(key);
            }
            //if There is some keys pressed do something
            if (pressedKeys != null||keysUp!=null)
            {
                OnKeysPressed(pressedKeys);
            }
        }
        #endregion

        #region OnEvent
        public virtual void OnKeysPressed(Keys[] pressedKeys)
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
                    eventData.KeysUp = keysUp;
                    InputEvent(this, eventData);
                }
            }
        }
        //public virtual void OnKeysUp()
        //{
        //    IList<Keys> keysUpList = keysUp;
        //    if (InputEvent != null)
        //    {

        //        IList<Keys> pressedEventKeys = new List<Keys>();
        //        for (int i = 0; i < keysUpList.Count; i++)
        //        {
        //            pressedEventKeys.Add(pressedKeys[i]);
        //        }

        //        if (pressedEventKeys.Count > 0)
        //        {

        //            InputEventArgs eventData = new InputEventArgs();
        //            eventData.KeysUp = keysUp;
        //            InputEvent(this, eventData);
        //        }
        //    }
        //}
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
