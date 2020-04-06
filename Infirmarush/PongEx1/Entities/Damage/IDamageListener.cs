using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    public interface IDamageListener
    {
        //On Damage Taken event
        void OnDamageTaken(object sender, IEvent args);
    }
}
