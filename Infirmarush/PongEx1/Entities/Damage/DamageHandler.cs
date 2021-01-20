using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    /// <summary>
    /// Handles the OnDamageEvent
    /// </summary>
    class DamageHandler:EvntHndlr,IDamageHandler
    {
        public override event EventHandler<IEvent> Event;
        public DamageHandler()
        {
            //set the event type to DamageEvent
            eventType = EventType.DamageEvent;
        }
        #region OnEvent
        /// <summary>
        /// Handles the Damage event
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="patientNum"></param>
        public void OnTakeDamage(double damage,PatientNum patientNum)
        {
            if (Event != null)
            {
                //INSTANTIATE a ReceiveDamageEvnt
                IEvent eventData = new ReceiveDamageEvent();
                //Create an IDicitonary for storing the damage and the patient num of the patient that will receive the damage
                IDictionary<PatientNum, double> dictDamage = ((ReceiveDamageEvent)eventData).Damage;
                //round the damage up to 2 decimal places
                damage=Math.Round(damage, 2);
                //set the integer in the dictDamage at the key of the patient number that has been passed
                dictDamage[patientNum] = damage;
                //set the damage dictionary property in the ReceiveDamage event args to local dictionary
                ((ReceiveDamageEvent)eventData).Damage=dictDamage;
                //send the event data to the event
                Event(this, eventData);
            }
        }
        #endregion
    }
}
