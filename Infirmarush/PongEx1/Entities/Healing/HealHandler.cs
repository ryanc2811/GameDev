using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    /// <summary>
    /// Handles the Healing event
    /// </summary>
    class HealHandler : EvntHndlr, IHealHandler
    {
        public override event EventHandler<IEvent> Event;
        public HealHandler()
        {
            //Sets the event type of the event to HealEvent
            eventType = EventType.HealEvent;
        }
        #region OnEvent
        /// <summary>
        /// Triggered when a class wants to heal a patient
        /// Handles the heal event
        /// </summary>
        /// <param name="heal"></param>
        /// <param name="patientNum"></param>
        public void OnHeal(double heal, PatientNum patientNum)
        {
            if (Event != null)
            {
                //INSTANTIATE a new ReceiveHealEvent
                IEvent eventData = new ReceiveHealEvent();
                //INSTANTIATE a Dictionairy with the event args dicitionary
                IDictionary<PatientNum, double> dictHeal = ((ReceiveHealEvent)eventData).Heal;
                //round the heal double to 2 decimal places
                heal=Math.Round(heal, 2);
                //add the double to the dictionary
                dictHeal[patientNum] = heal;
                //set the dictionairy property in the event args to the local dictionary
                ((ReceiveHealEvent)eventData).Heal=dictHeal;
                //send the event data to the event
                Event(this, eventData);
            }
        }
        #endregion
    }
}
