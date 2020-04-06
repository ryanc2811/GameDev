using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    class DeathHandler:EvntHndlr,IDeathHandler
    {
        public override event EventHandler<IEvent> Event;
        public DeathHandler()
        {
            eventType = EventType.DeathEvent;
        }
        #region OnEvent
        public void OnDeath(bool isDead, PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new DeathEvent();
                IDictionary<PatientNum, bool> dictDead;
                dictDead = ((DeathEvent)eventData).Dead;
                dictDead[patientNum] = isDead;
                ((DeathEvent)eventData).Dead = dictDead;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
