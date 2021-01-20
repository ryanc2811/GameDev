using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// Handles the activiy event
    /// </summary>
    class ActivityHandler :EvntHndlr, IActivityHandler
    {
        //Event for the activity event
        public override event EventHandler<IEvent> Event;
        public ActivityHandler()
        {
            //set the event type of the event to activity event
            eventType = EventType.ActivityEvent;
        }
        #region OnEvent 
        /// <summary>
        /// Handles the event
        /// </summary>
        /// <param name="ended"></param>
        /// <param name="patientNum"></param>
        public void OnActivityEnd(bool ended, PatientNum patientNum)
        {
            if (Event != null)
            {
                //INTIALISE the event
                IEvent eventData = new ActivityEvent();
                //Create a temporary IDictionary that stores booleans
                IDictionary<PatientNum, bool> dictEnded;
                //set dictEnded to the dictionary in the event args class
                dictEnded = ((ActivityEvent)eventData).Ended;
                //set the boolean at the key that relates to the patientNum that was passed
                dictEnded[patientNum] = ended;
                //set the property in the event args class to the temporary dictionary
                ((ActivityEvent)eventData).Ended = dictEnded;
                //pass the event data to the event
                Event(this, eventData);
            }
        }
        #endregion
    }
}
