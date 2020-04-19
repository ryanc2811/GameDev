using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Tools;
namespace PongEx1.Entities._Symbols
{
    class ToolSymbol:Symbol,IToolSymbol
    {
        public ToolType Tool { get; set; }
    }
}
