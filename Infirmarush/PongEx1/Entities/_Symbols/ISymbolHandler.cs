using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Holds all the symbols used in the game
    /// </summary>
    public interface ISymbolHandler
    {
        /// <summary>
        /// Gets the Symbols list
        /// </summary>
        IList<IEntity> Symbols { get; }
        /// <summary>
        /// Adds a symbol to the list
        /// </summary>
        /// <param name="entity"></param>
        void AddSymbol(IEntity entity);
    }
}
