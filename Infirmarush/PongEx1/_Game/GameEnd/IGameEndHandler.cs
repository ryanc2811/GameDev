using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{
    public interface IGameEndHandler
    {
        void OnGameEnd(bool hasEnded);
    }
}
