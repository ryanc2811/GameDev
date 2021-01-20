using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;

namespace PongEx1.Activity
{
    /// <summary>
    /// The quick time entity that sits in the background of the other two quick time objects
    /// </summary>
    class QTContainer : Container, IQuickTimeObj
    {
        //DECLARE a Vector2 for storing the start position of quick time object
        private Vector2 startPos;
        /// <summary>
        /// sets the quick time entity active
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            if (active)
                setPosition(startPos.X, startPos.Y);
            else
                setPosition(1111, 2222);
        }
        /// <summary>
        /// sets the start position of the quick time object for when the activity is active
        /// </summary>
        /// <param name="position"></param>
        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }
    }
}
