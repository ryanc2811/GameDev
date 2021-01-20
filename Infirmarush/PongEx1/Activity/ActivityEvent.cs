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
    /// The Event args class for storing the arguments of the Activity Event
    /// </summary>
    public class ActivityEvent:EventArgs,IEvent
    {
        //DECLARE an IDictionary for storing the boolean that checks if an activity has ended
        private IDictionary<PatientNum, bool> hasEnded = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Ended { get { return hasEnded; } set { hasEnded = value; } }
        public ActivityEvent()
        {
            //iterate over each value in the patient num enum
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //Intialise the dictionairy with a false boolean
                hasEnded.Add(num, false);
            }
        }
    }
}
