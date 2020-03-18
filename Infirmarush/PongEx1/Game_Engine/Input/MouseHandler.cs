using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Game_Engine.Input
{
    class MouseHandler : IInput
    {
        #region Variables 
        //DECLARE mouse Pos
        private Vector2 mousePos;
        //DECLARE left button
        private bool leftClicked;
        //DECLARE right button
        private bool rightClicked;
        //DECLARE Event Handler 
        public event EventHandler<InputEventArgs> InputEvent;
        #endregion

        #region Contructor
        public MouseHandler()
        {
            
        }
        #endregion

        #region Update
        public void Update()
        {
            //Update the mouse position
            mousePos =new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y);
            //Update if left button is pressed 
            leftClicked = Mouse.GetState().LeftButton == ButtonState.Pressed;
            //Update if right button is pressed 
            rightClicked = Mouse.GetState().RightButton == ButtonState.Pressed;

            if (mousePos!=null)
            {
                OnEvent(leftClicked,rightClicked,mousePos);
            }
        }
        #endregion

        #region On Event
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
