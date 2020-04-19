using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    class SymbolHandler :ISymbolHandler
    {
        private IList<IEntity> symbols;
        public IList<IEntity> Symbols { get { return symbols; } }
        public SymbolHandler()
        {
            symbols = new List<IEntity>();
        }
        public void AddSymbol(IEntity entity)
        {
            symbols.Add(entity);
        }
    } 
}
