using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    class GameTimer:EvntHndlr,IGameTimer
    {
        GameTime Time;
        float Timer;
        float time;
        bool timerStart = false;
        public override event EventHandler<IEvent> Event;
        public GameTimer()
        {
            eventType = EventType.TimerEvent;
        }
        private void OnTimerEnd()
        {
            IEvent eventData = new TimerEvent();
            ((TimerEvent)eventData).TimerEnd = true;
            Event(this, eventData);
            timerStart = false;
        }
        public void Update(GameTime gameTime)
        {
            Time = gameTime;
            
            if (timerStart)
            {
                if (Time.TotalGameTime.Seconds > Timer + time)
                {
                    OnTimerEnd();
                }
            }
        }
        #region OnEvent
        public void OnTimerStart(float time)
        {
            if (Event != null)
            {
                
                timerStart = true;
                this.time = time;
                Timer= Time.TotalGameTime.Seconds;
            }
        }
        #endregion
    }
}
