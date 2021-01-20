using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    public interface IBodyPartSymbol
    {
        //gets the body part type of the symbol
        BodyPart BodyPart { get; set; }
    }
}
