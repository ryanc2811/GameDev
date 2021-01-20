using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Tools;
namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// class for the Tool symbol
    /// </summary>
    class ToolSymbol:Symbol,IToolSymbol
    {
        /// <summary>
        /// gets and sets the type of tool that the symbol is for
        /// </summary>
        public ToolType Tool { get; set; }
    }
}
