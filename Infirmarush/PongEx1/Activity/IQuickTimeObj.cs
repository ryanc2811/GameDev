using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// interface for all the quick time objects
    /// </summary>
    public interface IQuickTimeObj
    {
        //sets the start position of the quick time object for when the activity is active
        void SetActivePosition(Vector2 position);
        //sets the quick time entity active
        void SetActive(bool active);
    }
}
