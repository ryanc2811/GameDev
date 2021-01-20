using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// interface for the Symptom symbol
    /// </summary>
    public interface ISymptomSymbol
    {
        /// <summary>
        /// gets and sets the Symptom type of the symbol
        /// </summary>
        Symptom Symptom { get; set; }
    }
}
