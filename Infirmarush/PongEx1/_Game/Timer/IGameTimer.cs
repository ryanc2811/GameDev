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
    /// interface for the GameTimer handler
    /// </summary>
    public interface IGameTimer
    {
        /// <summary>
        /// Updates the timer with GameTime
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);
        /// <summary>
        /// Starts the Timer
        /// </summary>
        /// <param name="time"></param>
        void OnTimerStart(float time);
        /// <summary>
        /// starts the timer for the corresponding patient
        /// </summary>
        /// <param name="time"></param>
        /// <param name="patientNum"></param>
        void OnTimerStart(float time, PatientNum patientNum);
        /// <summary>
        /// pauses the timer
        /// </summary>
        /// <param name="pause"></param>
        void OnTimerPause(bool pause);
        /// <summary>
        /// Sets the event type of the Handler
        /// </summary>
        /// <param name="eventType"></param>
        void SetEventType(EventType eventType);
    }
}
