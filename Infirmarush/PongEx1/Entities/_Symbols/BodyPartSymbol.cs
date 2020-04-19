using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    class BodyPartSymbol:Symbol,IBodyPartSymbol
    {
        public BodyPart BodyPart { get; set; }
    }
}
