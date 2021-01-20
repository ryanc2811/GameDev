using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    /// <summary>
    /// listens for the interact event
    /// </summary>
    public interface IInteractListener
    {
        /// <summary>
        /// Listens for the interact event to trigger
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnInteract(object sender, IEvent args);
    }
}
