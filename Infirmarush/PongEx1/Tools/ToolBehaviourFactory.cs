using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class ToolBehaviourFactory : IToolBehaviourFactory
    {
        public IToolBehaviour<T> Create<T>() where T : class
        {
            if (typeof(T) == typeof(BoneSawBehaviour))
            {
                return (IToolBehaviour<T>)new BoneSawBehaviour();
            }
            else
                throw new NotSupportedException();
        }
    }
}
