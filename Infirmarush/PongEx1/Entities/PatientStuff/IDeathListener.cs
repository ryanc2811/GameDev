using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// LISTENS FOR THE DEATH EVENT
    /// </summary>
    public interface IDeathListener
    {
        /// <summary>
        /// LISTENS FOR THE DEATH EVENT TO BE CALLED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void OnDeath(object sender, IEvent args);
    }
}
