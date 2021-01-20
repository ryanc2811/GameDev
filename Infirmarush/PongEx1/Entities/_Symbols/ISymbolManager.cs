using PongEx1.Entities.PatientStuff;
using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Manages the Symbols 
    /// </summary>
    public interface ISymbolManager
    {
        /// <summary>
        /// Adds an illness to the symbol manager
        /// </summary>
        /// <param name="illness"></param>
        /// <param name="patientNum"></param>
        void AddIllness(IIllness illness, PatientNum patientNum);
        /// <summary>
        /// adds the symbol handler and symbols to the symbol manager
        /// </summary>
        /// <param name="symbolHandler"></param>
        void AddSymbols(ISymbolHandler symbolHandler);
    }
}
