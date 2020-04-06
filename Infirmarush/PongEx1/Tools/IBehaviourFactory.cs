using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public interface IBehaviourFactory
    {
        IBehaviour Create<T>() where T : IBehaviour,new();
    }
}
