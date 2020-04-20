using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    /// <summary>
    /// Timer Event Class
    /// </summary>
    class TimerEvent: EventArgs,IEvent
    {
        //DECLARE a boolean for checking if the timer has ended
        private bool timerEnd = false;
        //returns the timer end variable
        public bool TimerEnd { get { return timerEnd; } set { timerEnd = value; } }
        //DECLARE a boolean to check of the timer has been paused
        private bool timerPaused= false;
        //returns the timer paused boolean
        public bool TimerPaused { get { return timerPaused; } set { timerPaused = value; } }
        //DECLARE an IDictionary for storing booleans to check if the timer has ended for each patient
        private IDictionary<PatientNum, bool> dictTimerEnd = new Dictionary<PatientNum, bool>();
        //returns the DictTimerEnd dictionary
        public IDictionary<PatientNum, bool> DictTimerEnd { get { return dictTimerEnd; } set { dictTimerEnd = value; } }
        public TimerEvent()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //set all the elements in the dictionary to false
                dictTimerEnd.Add(num, false);
            }
        }
    }
}
