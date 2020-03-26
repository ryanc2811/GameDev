using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public interface IToolBehaviourFactory
    {
        IToolBehaviour<T> Create<T>() where T : class;
    }
}
