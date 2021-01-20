using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// Event args for the death event, which stores the death state of the patient
    /// </summary>
    public class DeathEvent:EventArgs,IEvent
    {
        //DECLARE AN IDICTIONARY FOR STORING THE DEATH STATE OF EACH PATIENT
        private IDictionary<PatientNum, bool> isDead = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Dead { get { return isDead; } set { isDead = value; } }
        public DeathEvent()
        {
            //POPULATES THE DICTIONARY WITH DEFAULT VALUES
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                isDead.Add(num, false);
            }
        }
    }
}
