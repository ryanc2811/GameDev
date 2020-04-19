using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{ 
    class GameEndEvent:EventArgs,IEvent
    {
        private bool hasEnded = false;
        public bool Ended { get { return hasEnded; } set { hasEnded = value; } }
       
    }
}
