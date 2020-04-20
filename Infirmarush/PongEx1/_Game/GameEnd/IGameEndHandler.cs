using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{
    /// <summary>
    /// Interface for the GameEndHandler
    /// </summary>
    public interface IGameEndHandler
    {
        /// <summary>
        /// Method that handles the Game End Event
        /// </summary>
        /// <param name="hasEnded"></param>
        void OnGameEnd(bool hasEnded);
    }
}
