using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    /// <summary>
    /// interface for the timer listner object
    /// </summary>
    public interface ITimerListener
    {
        /// <summary>
        /// listens for the Timer Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnTimerStart(object sender, IEvent args);
    }
}
