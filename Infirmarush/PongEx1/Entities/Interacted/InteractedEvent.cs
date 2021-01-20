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
    /// Event args for the interact event. Stores the state of each patient being interacted with
    /// </summary>
    class InteractedEvent:EventArgs,IEvent
    {
        //DECLARE A IDICTIONARY FOR STORING THE STATE OF EACH PATIENT AND IF THEY HAVE BEEN INTERACTED WITH
        private IDictionary<PatientNum, bool> interacted = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Interacted { get { return interacted; } set { interacted = value; } }
        public InteractedEvent()
        {
            //POPULATE THE DICTIONARY WITH DEFAULT VALUES
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                interacted.Add(num, false);
            }
        }

    }
}
