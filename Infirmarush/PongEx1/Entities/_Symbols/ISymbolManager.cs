using PongEx1.Entities.PatientStuff;
using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    public interface ISymbolManager
    {
        void AddIllness(IIllness illness, PatientNum patientNum);
        void AddSymbols(ISymbolHandler symbolHandler);
    }
}
