using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    class ActivityHandler :EvntHndlr, IActivityHandler
    {
        public override event EventHandler<IEvent> Event;
        public ActivityHandler()
        {
            eventType = EventType.ActivityEvent;
        }
        #region OnEvent
        public void OnActivityChange(bool isActive,PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new ActivityEvent();
                IDictionary<PatientNum, bool> dictActive;
                dictActive = ((ActivityEvent)eventData).Active;
                dictActive[patientNum] = isActive;
                ((ActivityEvent)eventData).Active = dictActive;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
