using PongEx1._Game.GameEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    public interface ITimerEntity
    {
        void AddGameEndHandler(IGameEndHandler gameEndHandler);
    }
}
