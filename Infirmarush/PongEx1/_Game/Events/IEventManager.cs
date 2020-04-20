using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    /// <summary>
    /// Interface for the Event manager class that manages each event
    /// </summary>
    public interface IEventManager
    {
        /// <summary>
        /// Getter that returns the list of handlers
        /// </summary>
        IList<IEventHandler> Handlers { get; }
        /// <summary>
        /// adds an event handler to the handlers list
        /// </summary>
        /// <param name="eventHandler"></param>
        void AddEventHandler(IEventHandler handler);
        /// <summary>
        /// Adds a listener of an event to the handler
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        void AddEventListener(EventType eventType, EventHandler<IEvent> handler);
        /// <summary>
        /// removes a listener of an event to the handler
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="handler"></param>
        void RemoveEventListener(EventType eventType, EventHandler<IEvent> handler);
    }
}
