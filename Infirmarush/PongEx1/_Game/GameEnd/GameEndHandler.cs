using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{
    /// <summary>
    /// Class for Handling the Game End Event
    /// </summary>
    class GameEndHandler:EvntHndlr,IGameEndHandler
    {
        //Event for the GameEnd Handler
        public override event EventHandler<IEvent> Event;
        public GameEndHandler()
        {
            //set the event type to the GameEndEvent
            eventType = EventType.GameEndEvent;
        }
        #region OnEvent
        /// <summary>
        /// Handles the OnGameEnd Event
        /// </summary>
        /// <param name="hasEnded"></param>
        public void OnGameEnd(bool hasEnded)
        {
            if (Event != null)
            {
                //INSTANTIATE GameEndEvent
                IEvent eventData = new GameEndEvent();
                //Set the the Ended bool in GameEndEvent to the passed value
                ((GameEndEvent)eventData).Ended = hasEnded;
                //pass the sender and the event data to the event
                Event(this, eventData);
            }
        }
        #endregion
    }
}
