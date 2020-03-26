using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class ToolFactory : IToolFactory
    {
        public ITool create(string name)
        {
            ITool tool = new Tool(name); 
            return tool;
        }
    }
}
