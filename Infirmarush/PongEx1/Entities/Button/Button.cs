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
    /// <summary>
    /// Class for each button used in the game
    /// </summary>
    class Button : GameXEntity,ICollidable,IInputListener,IButton
    {
        //DECLARE a boolean for checking if the mouse is hovering over the button
        private bool isHovering=false;
        //DECLARE a boolean for checking if the button has been clicked
        private bool gotInput = false;
        //DECLARE a boolean for checking if the button has been released
        private bool released = false;
        //DECLAER an int for the offset of the buttons position
        private int offset = 10;
        public bool Clicked { get { return gotInput; } }
        public bool Released { get { return released; } }
        /// <summary>
        /// Gets the hitbox of the button
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X-offset, (int)entityLocn.Y-offset, texture.Width, texture.Height);
        }
        /// <summary>
        /// Triggered when an entity collides with the button
        /// </summary>
        /// <param name="entity"></param>
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
            //if the mouse is hovering over the button, change the colour of the button to Color.Gray
            if (isHovering)
                spriteColour = Color.Gray;
            else
            {
                spriteColour = Color.AntiqueWhite;
            }
            isHovering = false;
            
        }
        /// <summary>
        /// Checks for new mouse input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //store the left click variable locally
            bool clicked = args.LeftClicked;
            //store the released variable locally
            released = args.LeftReleased;
            //if the mouse is hovering over the button and the mouse has clicked
            if (isHovering && clicked)
            {
                //change the colour of the button
                spriteColour = Color.DarkGray;
            }
            //if the mouse is hovering over the button and the mouse has clicked and the gotInput boolean is false
            if (isHovering&&clicked&&!gotInput)
            {
                //button has been clicked
                gotInput = true;
                Console.WriteLine("button clicked");
                
            }
            //if the mouse has been released
            if (released)
            {
                //button released
                gotInput = false;
            }
        }
    }
}
