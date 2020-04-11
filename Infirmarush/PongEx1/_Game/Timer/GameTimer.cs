using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
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
        float totalTime;
        bool timerStart = false;
        bool timerPaused = false;
        PatientNum patientNum;
        public override event EventHandler<IEvent> Event;
        public GameTimer()
        {
            eventType = EventType.TimerEvent;
        }
        private void OnTimerEnd()
        {
            IEvent eventData = new TimerEvent();
            ((TimerEvent)eventData).TimerEnd = true;
            ((TimerEvent)eventData).DictTimerEnd[patientNum] = true;
            Event(this, eventData);
            timerStart = false;
            Console.WriteLine("timer End");
        }
        public void Update(GameTime gameTime)
        {

            Time = gameTime;
            if (timerStart&&!timerPaused)
            {
                if ((float)Time.TotalGameTime.TotalSeconds > Timer + totalTime)
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
                Console.WriteLine("timer Start");
                timerStart = true;
                totalTime = time;
                Timer= (float)Time.TotalGameTime.TotalSeconds;
            }
        }

        public void OnTimerPause(bool pause)
        {
            if (Event != null)
            {
                timerPaused = pause;
                IEvent eventData = new TimerEvent();
                ((TimerEvent)eventData).TimerPaused = timerPaused;
                Event(this, eventData);
            }
        }
        public void OnTimerStart(float time,PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new TimerEvent();
                ((TimerEvent)eventData).DictTimerEnd[patientNum] = false;
                Event(this, eventData);
                Console.WriteLine("timer Start");
                this.patientNum = patientNum;
                timerStart = true;
                totalTime = time;
                Timer = (float)Time.TotalGameTime.TotalSeconds;
            }
        }

        public void OnTimerPause(bool pause, PatientNum patientNum)
        {
            if (Event != null)
            {
                timerPaused = pause;
                IEvent eventData = new TimerEvent();
                ((TimerEvent)eventData).TimerPaused = timerPaused;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
