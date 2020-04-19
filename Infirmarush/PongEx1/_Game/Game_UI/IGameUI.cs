using PongEx1._Game.Timer;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    public interface IGameUI
    {
        void Update();
        void AddUIElement(IEntity entity);
        void AddGameTimer(IGameTimer gameTimer);
    }
}
