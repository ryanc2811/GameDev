using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Events
{
    /// <summary>
    /// Enum for each type of event
    /// </summary>
    public enum EventType
    {
        ActivityEvent,
        DamageEvent,
        DeathEvent,
        DeathTimerEvent,
        HealEvent,
        InteractEvent,
        GameTimerEvent,
        GameEndEvent
        
    }
}
