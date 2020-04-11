using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    class InteractedEvent:EventArgs,IEvent
    {
        private IDictionary<PatientNum, bool> interacted = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Interacted { get { return interacted; } set { interacted = value; } }
        public InteractedEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                interacted.Add(num, false);
            }
        }

    }
}
