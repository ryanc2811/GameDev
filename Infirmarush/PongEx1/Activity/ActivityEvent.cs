using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    public class ActivityEvent:EventArgs,IEvent
    {
       
        private IDictionary<PatientNum, bool> isActive = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Active { get { return isActive; } set { isActive = value; } }
        public ActivityEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                isActive.Add(num, false);
            }
        }
    }
}
