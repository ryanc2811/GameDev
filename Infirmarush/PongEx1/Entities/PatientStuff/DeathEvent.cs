using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    public class DeathEvent:EventArgs,IEvent
    {
        private IDictionary<PatientNum, bool> isDead = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> Dead { get { return isDead; } set { isDead = value; } }
        public DeathEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                isDead.Add(num, false);
            }
        }
    }
}
