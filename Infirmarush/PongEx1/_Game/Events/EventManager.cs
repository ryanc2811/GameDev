using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    class EventManager:IEventManager
    {
        private IList<IEventHandler> handlers;
        public IList<IEventHandler> Handlers { get { return handlers; } }
        public EventManager()
        {
            handlers = new List<IEventHandler>();
        }
        public void AddEventHandler(IEventHandler eventHandler)
        {
            handlers.Add(eventHandler);
        }
        #region Add / Remove Device / Listener
        //Add listener to handler
        public void AddEventListener(EventType eventType,EventHandler<IEvent> handler)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].GetType == eventType)
                {
                    handlers[i].AddEventHandler(handler);
                }
            }
        }
        //Remove listener from handler
        public void RemoveEventListener(EventType eventType,EventHandler<IEvent> handler)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                if (handlers[i].GetType == eventType)
                {
                    handlers[i].RemoveEventHandler(handler);
                }
            }
        }
        #endregion
    }
}
