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
    /// <summary>
    /// Handles the Timer Event
    /// </summary>
    class GameTimer:EvntHndlr,IGameTimer
    {
        //DECLARE a GameTime
        private GameTime Time;
        //DECLARE a float for the timer
        private float Timer;
        //DECLARE a float for the total time that the timer must last
        private float totalTime;
        //DECLARE a bool to check if the timer has started
        private bool timerStart = false;
        //DECLARE a bool to check if the timer has paused
        private bool timerPaused = false;
        //DECLARE a PatientNum for storing the patient number that the timer is a assigned to
        private PatientNum patientNum;
        public override event EventHandler<IEvent> Event;
        
        /// <summary>
        /// Triggers the event when the timer ends
        /// </summary>
        private void OnTimerEnd()
        {
            //INSTANTIATE a TimerEvent
            IEvent eventData = new TimerEvent();
            //Set the TimerEnd boolean in Timer event to true
            ((TimerEvent)eventData).TimerEnd = true;
            //set the ended boolean for the current player to true
            ((TimerEvent)eventData).DictTimerEnd[patientNum] = true;
            //Send the event data to the listeners
            Event(this, eventData);
            timerStart = false;
            Console.WriteLine("timer End");
        }
        /// <summary>
        /// Updates the Timer with the GameTime
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //set the GameTime locally
            Time = gameTime;
            //if the timer has started and hasnt paused
            if (timerStart&&!timerPaused)
            {
                //if the Timer has ended
                if ((float)Time.TotalGameTime.TotalSeconds > Timer + totalTime)
                {
                    OnTimerEnd();
                }
            }
        }
        #region OnEvent
        /// <summary>
        /// Starts the Timer
        /// </summary>
        /// <param name="time"></param>
        public void OnTimerStart(float time)
        {
            if (Event != null)
            {
                Console.WriteLine("timer Start");
                //set timer start bool to true
                timerStart = true;
                //set the total time for the timer to the passed value
                totalTime = time;
                //set the timer to the current Total Game time
                if (Time != null)
                    Timer = (float)Time.TotalGameTime.TotalSeconds;
            }
        }
        /// <summary>
        /// Start the Timer
        /// </summary>
        /// <param name="time"></param>
        /// <param name="patientNum"></param>
        public void OnTimerStart(float time, PatientNum patientNum)
        {
            if (Event != null)
            {
                //INSTANTIATE a Timer Event
                IEvent eventData = new TimerEvent();
                //set the timer end boolean for the current patient to false
                ((TimerEvent)eventData).DictTimerEnd[patientNum] = false;
                //Send the event data to the listener
                Event(this, eventData);
                Console.WriteLine("timer Start");
                //set the patient number locally
                this.patientNum = patientNum;
                //set the timer start boolean to true
                timerStart = true;
                //set the total time for the timer to the passed value
                totalTime = time;
                //set the timer to the current Total Game time
                if (Time!=null)
                    Timer = (float)Time.TotalGameTime.TotalSeconds;
            }
        }
        /// <summary>
        /// pauses the timer
        /// </summary>
        /// <param name="pause"></param>
        public void OnTimerPause(bool pause)
        {
            if (Event != null)
            {
                //set the timer paused boolean to the passed value
                timerPaused = pause;
                //INSTANTIATE a new Timer Event
                IEvent eventData = new TimerEvent();
                //set the timer paused boolean in the Timer event to locak timer paused boolean
                ((TimerEvent)eventData).TimerPaused = timerPaused;
                //Send the event data to the listener
                Event(this, eventData);
            }
        }
        /// <summary>
        /// Sets the event Type of the Event
        /// </summary>
        /// <param name="eventType"></param>
        public void SetEventType(EventType eventType)
        {
            this.eventType = eventType;
        }

        #endregion
    }
}
