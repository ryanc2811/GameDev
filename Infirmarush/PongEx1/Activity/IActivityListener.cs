using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    public interface IActivityListener
    {
        //On Activity Change event
        void OnActivityEnd(object sender, IEvent args);
    }
}
