using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Stores all the symbols in the game
    /// </summary>
    class SymbolHandler :ISymbolHandler
    {
        //DECLARE an IList that stores all the symbols in the game
        private IList<IEntity> symbols;
        public IList<IEntity> Symbols { get { return symbols; } }
        public SymbolHandler()
        {
            symbols = new List<IEntity>();
        }
        /// <summary>
        /// add a symbol to the symbols list
        /// </summary>
        /// <param name="entity"></param>
        public void AddSymbol(IEntity entity)
        {
            symbols.Add(entity);
        }
    } 
}
