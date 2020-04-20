using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{
    /// <summary>
    /// interface for the Game end listener
    /// </summary>
    public interface IGameEndListener
    {
        /// <summary>
        /// Method that triggers when the on game event triggers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnGameEnd(object sender, IEvent args);
    }
}
