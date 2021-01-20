using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Symbol for body part
    /// </summary>
    class BodyPartSymbol:Symbol,IBodyPartSymbol
    {
        //gets the Bodypart type of the symbol
        public BodyPart BodyPart { get; set; }
    }
}
