using PongEx1._Game.Timer;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Interface for the Game UI
    /// </summary>
    public interface IGameUI
    {
        //Updates every frame
        void Update();
        //Adds a UI element to the GameUI
        void AddUIElement(IEntity entity);
        //Adds the Game Timer Handler to the GameUI
        void AddGameTimer(IGameTimer gameTimer);
    }
}
