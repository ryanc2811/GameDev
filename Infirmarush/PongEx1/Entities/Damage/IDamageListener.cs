using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    /// <summary>
    /// interface for the entities that listen to the damage event
    /// </summary>
    public interface IDamageListener
    {
        //On Damage Taken event
        void OnDamageTaken(object sender, IEvent args);
    }
}
