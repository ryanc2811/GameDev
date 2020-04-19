using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    public interface ISymbolHandler
    {
        IList<IEntity> Symbols { get; }
        void AddSymbol(IEntity entity);
    }
}
