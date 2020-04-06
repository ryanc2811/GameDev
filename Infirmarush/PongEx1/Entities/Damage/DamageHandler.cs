using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    class DamageHandler:EvntHndlr,IDamageHandler
    {
        public override event EventHandler<IEvent> Event;
        public DamageHandler()
        {
            eventType = EventType.DamageEvent;
        }
        #region OnEvent
        public void OnTakeDamage(int damage,PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new ReceiveDamageEvent();
                IDictionary<PatientNum, int> dictDamage = ((ReceiveDamageEvent)eventData).Damage;
                dictDamage[patientNum] = damage;
                ((ReceiveDamageEvent)eventData).Damage=dictDamage;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
