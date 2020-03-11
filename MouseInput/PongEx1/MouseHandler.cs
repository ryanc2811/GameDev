using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    class MouseHandler : IInput
    {
        private Vector2 mousePos;
        private bool leftClicked;
        private bool rightClicked;
        public event EventHandler<InputEventArgs> InputEvent;
     
        public MouseHandler()
        {
            
        }
        public void Update()
        {
            mousePos =new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            leftClicked = Mouse.GetState().LeftButton == ButtonState.Pressed;
            rightClicked = Mouse.GetState().RightButton == ButtonState.Pressed;
            if (mousePos!=null)
            {
                OnEvent(leftClicked,rightClicked,mousePos);
            }
        }

        public virtual void OnEvent(bool leftClicked,bool rightClicked,Vector2 mousePos)
        {
            if (InputEvent != null)
            {
                InputEventArgs eventData = new InputEventArgs();
                eventData.LeftClicked = leftClicked;
                eventData.RightClicked = rightClicked;
                eventData.MousePos = mousePos;
                InputEvent(this, eventData);
               
            }
        }

        public void AddEventHandler(EventHandler<InputEventArgs> handler)
        {
            InputEvent += handler;
        }

        public void RemoveEventHandler(EventHandler<InputEventArgs> handler)
        {
            InputEvent -= handler;
        }
    }
}
