using PongEx1.Entities._Symbols;
using PongEx1.Entities.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Hand_Book
{
    public interface IHandBook
    {
        void AddSymbolButton(SymbolType symbolType, IButton symbolButton);
        void AddSymbolHandler(ISymbolHandler symbolHandler);
        void AddHandBookButton(IButton symbolButton);
        void AddIllnessCalculator(IIllnessCalculator illnessCalculator);
        void AddResetButton(IButton resetButton);
    }
}
