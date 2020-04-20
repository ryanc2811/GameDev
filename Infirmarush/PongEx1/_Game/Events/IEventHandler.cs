using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    /// <summary>
    /// Interface for the Event handlers
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Getter for the type of event
        /// </summary>
        EventType GetType { get; }
        /// <summary>
        /// Subscribes the listener to the event
        /// </summary>
        /// <param name="handler"></param>
        void AddEventListener(EventHandler<IEvent> handler);
        /// <summary>
        /// Unsubscribes the listener to the event
        /// </summary>
        /// <param name="handler"></param>
        void RemoveEventListener(EventHandler <IEvent>handler);
    }
}
