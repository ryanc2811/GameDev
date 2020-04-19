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
        public void OnActivityEnd(bool ended, PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new ActivityEvent();
                IDictionary<PatientNum, bool> dictEnded;
                dictEnded = ((ActivityEvent)eventData).Ended;
                dictEnded[patientNum] = ended;
                ((ActivityEvent)eventData).Ended = dictEnded;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
