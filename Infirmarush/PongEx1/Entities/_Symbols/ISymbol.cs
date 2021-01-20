using Microsoft.Xna.Framework;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// interface for symbols
    /// </summary>
    public interface ISymbol
    {
        /// <summary>
        /// gets the symbol type of the symbol
        /// </summary>
        SymbolType SymbolType { get; set; }
        /// <summary>
        /// Gets the Patient number that corrsponds to the symbol
        /// </summary>
        PatientNum Patient { get; set; }
        /// <summary>
        /// gets the boolean that checks if the symbol will be used in the handbook
        /// </summary>
        bool usedInHandbook { get; set; }
        /// <summary>
        /// Sets the symbol active/not active
        /// </summary>
        /// <param name="isActive"></param>
        void SetActive(bool isActive);
        /// <summary>
        /// Sets the starting position of the symbol
        /// </summary>
        /// <param name="pStartPos"></param>
        void SetStartPos(Vector2 pStartPos);
    }
}
