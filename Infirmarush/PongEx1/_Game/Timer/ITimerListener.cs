using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    public interface ITimerListener
    {
        //On Activity Change event
        void OnTimerStart(object sender, IEvent args);
    }
}
