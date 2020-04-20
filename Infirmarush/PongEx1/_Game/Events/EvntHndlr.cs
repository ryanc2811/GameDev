using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    /// <summary>
    /// Abstract event handler class that each event handler inherits
    /// </summary>
    public abstract class EvntHndlr:IEventHandler
    {
        public virtual event EventHandler<IEvent> Event;
        //Type of event
        protected EventType eventType;
        //getter for returning the event type
        public EventType GetType { get { return eventType; } }
        #region Add/Remove Event Handler
        /// <summary>
        /// Subscribes the event listener to the event
        /// </summary>
        /// <param name="handler"></param>
        public void AddEventListener(EventHandler<IEvent> handler)
        {
            Event += handler;
        }

         /// <summary>
         /// Unsubscribes the event listener from the event
         /// </summary>
         /// <param name="handler"></param>
        public void RemoveEventListener(EventHandler<IEvent> handler)
        {
            Event -= handler;
        }
        #endregion

    }
}
