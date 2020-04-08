using PongEx1._Game.Events;
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
    }
}
