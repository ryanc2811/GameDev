using PongEx1._Game.GameEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Interface for the Timer Entity
    /// </summary>
    public interface ITimerEntity
    {
        /// <summary>
        /// Adds the handler fo the Game End Event
        /// </summary>
        /// <param name="gameEndHandler"></param>
        void AddGameEndHandler(IGameEndHandler gameEndHandler);
    }
}
