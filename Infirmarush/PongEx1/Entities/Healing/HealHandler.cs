using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    class HealHandler : EvntHndlr, IHealHandler
    {
        public override event EventHandler<IEvent> Event;
        public HealHandler()
        {
            eventType = EventType.HealEvent;
        }
        #region OnEvent
        public void OnHeal(double heal, PatientNum patientNum)
        {
            if (Event != null)
            {
                IEvent eventData = new ReceiveHealEvent();
                IDictionary<PatientNum, double> dictHeal = ((ReceiveHealEvent)eventData).Heal;
                heal=Math.Round(heal, 2);
                dictHeal[patientNum] = heal;
                ((ReceiveHealEvent)eventData).Heal=dictHeal;
                Event(this, eventData);
            }
        }
        #endregion
    }
}
