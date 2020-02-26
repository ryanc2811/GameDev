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
        private IList<Keys> EventKeys;
        public event EventHandler<EventArgs> InputEvent;
        public void Update()
        {
            
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
    }
}
