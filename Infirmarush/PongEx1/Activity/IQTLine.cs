using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// Interface for Quick time line entity
    /// </summary>
    public interface IQTLine
    {
        //gets the boolean that checks if the line has intersected with the green quick time entity
        bool gethasHitGreen { get; }
    }
}
