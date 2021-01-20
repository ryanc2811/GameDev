using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    /// <summary>
    /// Handles the Interact Event
    /// </summary>
    class InteractHandler:EvntHndlr,IInteractHandler
    {
        public override event EventHandler<IEvent> Event;
        public InteractHandler()
        {
            //Set the Event typ of the Event to InteractEvent
            eventType = EventType.InteractEvent;
        }
        #region OnEvent
        /// <summary>
        /// Triggered when the player interacts with a patient
        /// handles the interact event
        /// </summary>
        /// <param name="interact"></param>
        /// <param name="patientNum"></param>
        public void OnInteract(bool interact, PatientNum patientNum)
        {
            if (Event != null)
            {
                //INSTANTIATE a InteractEvent
                IEvent eventData = new InteractedEvent();
                //INSTANTIATE A DICTIONARY and set it to the dictionary from event data
                IDictionary<PatientNum, bool> dictInteract = ((InteractedEvent)eventData).Interacted;
                //Add the passed boolean at the key that links with the passed PatientNum to the dictionary
                dictInteract[patientNum] = interact;
                //Set the dictionary property in the event args to the local dictionary
                ((InteractedEvent)eventData).Interacted = dictInteract;
                //Send the event data to the event
                Event(this, eventData);
            }
        }
        #endregion
    }
}
