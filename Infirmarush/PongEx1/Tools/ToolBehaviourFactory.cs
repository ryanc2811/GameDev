using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class ToolBehaviourFactory : IBehaviourFactory
    {
        public IBehaviour Create<T>() where T : IBehaviour, new()
        {
            return new T();
        }
    }
}
