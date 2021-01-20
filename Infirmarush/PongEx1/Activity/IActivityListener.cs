using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// Iterface for the entity that listens to the Activity Event
    /// </summary>
    public interface IActivityListener
    {
        //On Activity Change event
        void OnActivityEnd(object sender, IEvent args);
    }
}
