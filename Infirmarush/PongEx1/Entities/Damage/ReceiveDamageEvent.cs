using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    public class ReceiveDamageEvent : EventArgs, IEvent
    {
     
        private IDictionary<PatientNum, double> damage = new Dictionary<PatientNum, double>();
        public IDictionary<PatientNum, double> Damage { get { return damage; } set { damage = value; } }
        public ReceiveDamageEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                damage.Add(num, 0.0);
            }
        }
        
    }
}
