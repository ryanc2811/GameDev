using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.GameEnd
{ 
    /// <summary>
    /// class for the Game End Event
    /// </summary>
    class GameEndEvent:EventArgs,IEvent
    {
        //DECLARE a bool for checking if the Game has ended
        private bool hasEnded = false;
        //Getter Setter for the hasEnded variable
        public bool Ended { get { return hasEnded; } set { hasEnded = value; } }       
    }
}
