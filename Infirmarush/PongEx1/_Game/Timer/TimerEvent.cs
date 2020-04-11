using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    class TimerEvent: EventArgs,IEvent
    {
        private bool timerEnd = false;
        public bool TimerEnd { get { return timerEnd; } set { timerEnd = value; } }
        private bool timerPaused= false;
        public bool TimerPaused { get { return timerPaused; } set { timerPaused = value; } }
        private IDictionary<PatientNum, bool> dictTimerEnd = new Dictionary<PatientNum, bool>();
        public IDictionary<PatientNum, bool> DictTimerEnd { get { return dictTimerEnd; } set { dictTimerEnd = value; } }
        public TimerEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                dictTimerEnd.Add(num, false);
            }
        }
    }
}
