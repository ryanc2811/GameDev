using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public abstract class ToolBehaviour : IToolBehaviour<ToolBehaviour>
    {
        protected bool isActive = false;
        public abstract void Behaviour();
    }
}
