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
    /// Event args for the Receive heal event. Stores the health amount that will be used heal the patient
    /// </summary>
    public class ReceiveHealEvent : EventArgs, IEvent
    {
        //DECLARE AN IDICTIONARY FOR STORING THE AMOUNT OF HEALTH THAT THE PATIENT WILL BE HEALED FOR
        private IDictionary<PatientNum, double> heal = new Dictionary<PatientNum, double>();
        public IDictionary<PatientNum, double> Heal { get { return heal; } set { heal = value; } }
        public ReceiveHealEvent()
        {
            //POPULATE THE DICTIONARY WITH VALUES SO IT IS NOT EMPTY
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                heal.Add(num, 0.0);
            }
        }
        
    }
}
