using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using PongEx1.Entities;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// Quick time object that the Quick time line collides with
    /// </summary>
    class QTGreen : GameXEntity, IShape,ICollidable,IQuickTimeObj
    {
        //DECLARE a Vector2 for storing the start position of the quick time object
        private Vector2 startPos;
        /// <summary>
        /// Gets the texture width
        /// </summary>
        /// <returns>Texture width</returns>
        public int getWidth()
        {
            return texture.Width;
        }
        /// <summary>
        /// Gets the hitbox of the entity
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            //do nothing
        }
        /// <summary>
        ///  sets the quick time entity active
        /// </summary>
        /// <param name="position"></param>
        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }
        /// <summary>
        /// sets the start position of the quick time object for when the activity is active
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            if (active)
                setPosition(startPos.X, startPos.Y);
            else
                setPosition(1111, 2222);
        }
    }
}
