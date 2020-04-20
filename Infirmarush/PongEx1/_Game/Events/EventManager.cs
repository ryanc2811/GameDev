using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    /// <summary>
    /// This class manages each IEventHandler
    /// </summary>
    class EventManager:IEventManager
    {
        //DECLARE an IList of type IEventHandler to store all the event handlers
        private IList<IEventHandler> handlers;
        //Getter that returns the list of handlers
        public IList<IEventHandler> Handlers { get { return handlers; } }
        public EventManager()
        {
            //INSTANTIATE the handlers list
            handlers = new List<IEventHandler>();
        }
        /// <summary>
        /// adds an event handler to the handlers list
        /// </summary>
        /// <param name="eventHandler"></param>
        public void AddEventHandler(IEventHandler eventHandler)
        {
            handlers.Add(eventHandler);
        }
        #region Add / Remove Listener
        /// <summary>
        /// Adds a listener of an event to the handler
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        public void AddEventListener(EventType eventType,EventHandler<IEvent> handler)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                //if the event type of the handler is the same as the passed value, then add the listener to the handler
                if (handlers[i].GetType == eventType)
                {
                    handlers[i].AddEventListener(handler);
                }
            }
        }
        /// <summary>
        /// removes a listener of an event to the handler
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(EventType eventType,EventHandler<IEvent> handler)
        {
            for (int i = 0; i < handlers.Count; i++)
            {
                //if the event type of the handler is the same as the passed value, then remove the listener to the handler
                if (handlers[i].GetType == eventType)
                {
                    handlers[i].RemoveEventListener(handler);
                }
            }
        }
        #endregion
    }
}
