using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using PongEx1.Entities.Mouse;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1.Entities.Button
{
    class Button : GameXEntity,ICollidable,IInputListener,IButton
    {
        protected bool isHovering=false;
        protected bool gotInput = false;
        private int offset = 10;

        public bool clicked { get { return gotInput; } }

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
            //draw the entity using the spritebatch
            
        }   
        public void OnNewInput(object sender, InputEventArgs args)
        {
            bool clicked = args.LeftClicked;
            bool released = args.LeftReleased;
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
