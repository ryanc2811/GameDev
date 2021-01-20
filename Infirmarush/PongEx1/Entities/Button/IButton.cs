using PongEx1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Button
{
    /// <summary>
    /// interface for the button class
    /// </summary>
    public interface IButton
    {
        /// <summary>
        /// gets the clicked state of the button
        /// </summary>
        bool Clicked { get; }
        /// <summary>
        /// gets the released state of the button
        /// </summary>
        bool Released { get; }
    }
}
