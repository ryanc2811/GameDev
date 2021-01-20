using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Mouse
{
    /// <summary>
    /// Entity that is used to check for collision with the cursor
    /// </summary>
    class MouseEntity : GameXEntity, ICollidable,IInputListener
    {
        //offset of the mouse position
        private float offset = 10f;
        /// <summary>
        /// Gets the hitbox of the mouse entity
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, 1, 1);
        }

        public void onCollide(IEntity entity)
        {
            //do nothing
        }
        /// <summary>
        /// Method that listens for new input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //move the mouse entity position to the cursor position
            entityLocn.X = args.MousePos.X - offset;
            entityLocn.Y = args.MousePos.Y - offset;
        }
    }
}
