using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    public interface IDeathListener
    {
        //On Actity Change event
        void OnDeath(object sender, IEvent args);
    }
}
