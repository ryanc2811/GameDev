using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{
    class GameEndHandler:EvntHndlr,IGameEndHandler
    {
        public override event EventHandler<IEvent> Event;
        public GameEndHandler()
        {
            eventType = EventType.GameEndEvent;
        }
        #region OnEvent
        public void OnGameEnd(bool hasEnded)
        {
            if (Event != null)
            {
                IEvent eventData = new GameEndEvent();
                ((GameEndEvent)eventData).Ended = hasEnded;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
