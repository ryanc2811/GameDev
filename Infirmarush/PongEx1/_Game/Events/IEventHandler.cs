using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    public interface IEventHandler
    {
        //Update 
        EventType GetType { get; }
        void AddEventHandler(EventHandler<IEvent> handler);
        void RemoveEventHandler(EventHandler <IEvent>handler);
    }
}
