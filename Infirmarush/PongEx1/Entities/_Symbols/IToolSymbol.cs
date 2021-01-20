using PongEx1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Interface for the Tool symbol
    /// </summary>
    public interface IToolSymbol
    {
        /// <summary>
        /// gets and sets the tool type of the symbol
        /// </summary>
        ToolType Tool { get; set; }
    }
}
