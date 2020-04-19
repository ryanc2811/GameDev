using Microsoft.Xna.Framework.Graphics;
using PongEx1._Game.Events;
using PongEx1._Game.GameEnd;
using PongEx1._Game.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    class TimerUI : TextEntity, ITimerListener,ITimerEntity
    {
        private bool hasEnded=false;
        private float timer=3600f;
        private IGameEndHandler _gameEndHandler;
        public void AddGameEndHandler(IGameEndHandler gameEndHandler)
        {
            _gameEndHandler = gameEndHandler;
        }

        public void OnTimerStart(object sender, IEvent args)
        {
            if (((TimerEvent)args).TimerEnd)
            {
                hasEnded = true;
                _gameEndHandler.OnGameEnd(true);
            }
                
        }
        public override void Update()
        {
            if (!hasEnded)
            {
                timer--;
                float convertedTimer = timer / 60f;
                text = convertedTimer.ToString("00");
            }

        }
      
    }
}
