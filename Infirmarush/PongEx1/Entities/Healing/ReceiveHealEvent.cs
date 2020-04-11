using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    public class ReceiveHealEvent : EventArgs, IEvent
    {
     
        private IDictionary<PatientNum, double> heal = new Dictionary<PatientNum, double>();
        public IDictionary<PatientNum, double> Heal { get { return heal; } set { heal = value; } }
        public ReceiveHealEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                heal.Add(num, 0.0);
            }
        }
        
    }
}
