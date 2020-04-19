using Microsoft.Xna.Framework;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    public interface ISymbol
    {
        SymbolType SymbolType { get; set; }
        PatientNum Patient { get; set; }
        bool usedInHandbook { get; set; }
        void SetActive(bool isActive);
        void SetStartPos(Vector2 pStartPos);
    }
}
