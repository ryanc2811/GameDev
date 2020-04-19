using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using PongEx1.Entities._Mouse;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1.Entities.Button
{
    class Button : GameXEntity,ICollidable,IInputListener,IButton
    {
        private bool isHovering=false;
        private bool gotInput = false;
        private bool released = false;
        private int offset = 10;

        public bool Clicked { get { return gotInput; } }
        public bool Released { get { return released; } }

        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X-offset, (int)entityLocn.Y-offset, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            if(entity is MouseEntity)
            {
                //is hovering to true
                isHovering = true;
            }
        }
        
        public override void Update()
        {
            if (isHovering)
                spriteColour = Color.Gray;
            else
            {
                spriteColour = Color.AntiqueWhite;
            }
            isHovering = false;
            
        }   
        public void OnNewInput(object sender, InputEventArgs args)
        {
            
            bool clicked = args.LeftClicked;
            released = args.LeftReleased;
            if (isHovering && clicked)
            {
                spriteColour = Color.DarkGray;
            }
            if (isHovering&&clicked&&!gotInput)
            {
                gotInput = true;
                Console.WriteLine("button clicked");
                
            }
            if (released)
            {
                gotInput = false;
            }
        }
    }
}
