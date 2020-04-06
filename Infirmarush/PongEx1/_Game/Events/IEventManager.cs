using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    public interface IEventManager
    {
        IList<IEventHandler> Handlers { get; }
        void AddEventHandler(IEventHandler handler);
        //Add Listener to the list
        void AddEventListener(EventType eventType, EventHandler<IEvent> handler);
        //remove Listener from the List
        void RemoveEventListener(EventType eventType, EventHandler<IEvent> handler);
        
    }
}
