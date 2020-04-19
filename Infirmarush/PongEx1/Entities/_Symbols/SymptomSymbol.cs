using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    class SymptomSymbol:Symbol,ISymptomSymbol
    {
        public Symptom Symptom { get; set; }
    }
}
