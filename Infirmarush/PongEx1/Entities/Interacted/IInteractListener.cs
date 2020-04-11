using PongEx1._Game.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    public interface IInteractListener
    {
        void OnInteract(object sender, IEvent args);
    }
}
