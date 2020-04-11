using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    class InteractHandler:EvntHndlr,IInteractHandler
    {
        public override event EventHandler<IEvent> Event;
        public InteractHandler()
        {
            eventType = EventType.InteractEvent;
        }
        #region OnEvent
        public void OnInteract(bool interact, PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new InteractedEvent();
                IDictionary<PatientNum, bool> dictInteract = ((InteractedEvent)eventData).Interacted;
                dictInteract[patientNum] = interact;
                ((InteractedEvent)eventData).Interacted = dictInteract;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
