using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    /// <summary>
    /// INTERFACE FOR THE TOOL FACTORY, WHICH CREATE AND RETURNS TOOLS
    /// </summary>
    public interface IToolFactory
    {
        /// <summary>
        /// CREATE AND RETURN A TOOL WITH A GIVEN NAME
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ITool create(string name);
    }
}
