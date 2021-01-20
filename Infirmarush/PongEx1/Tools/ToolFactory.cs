using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    /// <summary>
    /// CREATES AND RETURNS A NEW TOOL
    /// </summary>
    class ToolFactory : IToolFactory
    {
        /// <summary>
        /// CREATES AND RETURNS A NEW TOOL WITH THE GIVEN NAME
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ITool create(string name)
        {
            //INSTANTATE A TOOL
            ITool tool = new Tool(name); 
            //RETURN THE TOOL
            return tool;
        }
    }
}
