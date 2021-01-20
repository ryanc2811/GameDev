using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// class for Symbols that are for symptoms
    /// </summary>
    class SymptomSymbol:Symbol,ISymptomSymbol
    {
        /// <summary>
        /// gets and set the symptom type of the symbol
        /// </summary>
        public Symptom Symptom { get; set; }
    }
}
