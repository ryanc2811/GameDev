using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    public abstract class EvntHndlr:IEventHandler
    {
        public virtual event EventHandler<IEvent> Event;
        protected EventType eventType;
        public EventType GetType { get { return eventType; } }
        #region Add/Remove Event Handler
        public void AddEventHandler(EventHandler<IEvent> handler)
        {
            Event += handler;
        }

     
        public void RemoveEventHandler(EventHandler<IEvent> handler)
        {
            Event -= handler;
        }
        #endregion

    }
}
