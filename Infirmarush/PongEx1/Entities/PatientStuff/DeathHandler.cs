using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// Handles the death event
    /// </summary>
    class DeathHandler:EvntHndlr,IDeathHandler
    {
        public override event EventHandler<IEvent> Event;
        public DeathHandler()
        {
            //SET THE EVENT TYPE OF THE EVENT TO DEATH EVENT
            eventType = EventType.DeathEvent;
        }
        #region OnEvent
        /// <summary>
        /// TRIGGERED WHEN A PATIENT DIES
        /// HANDLES THE DEATH EVENT
        /// </summary>
        /// <param name="isDead"></param>
        /// <param name="patientNum"></param>
        public void OnDeath(bool isDead, PatientNum patientNum)
        {
            if (Event != null)
            {
                //INSTANTIATE A DEATH EVENT
                IEvent eventData = new DeathEvent();
                //INSTANTIATE A DICTIONARY AND SET IT TO THE DICTIONARY FROM THE EVENT ARGS
                IDictionary<PatientNum, bool> dictDead=((DeathEvent)eventData).Dead;
                //STORE THE ISDEAD BOOLEAN IN THE DICTIONARY
                dictDead[patientNum] = isDead;
                //SET THE DICTIONARY PROPERTY TO THE LOCAL DICTIONARY
                ((DeathEvent)eventData).Dead = dictDead;
                //SEND THE EVENT DATA TO THE EVENT
                Event(this, eventData);
            }
        }
        #endregion
    }
}
