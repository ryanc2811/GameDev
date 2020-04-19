using PongEx1.Entities._Symbols;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Hand_Book
{
    public interface IIllnessCalculator
    {
        IEntity CalculateIllness(ISymptomSymbol symbolSlot1, ISymptomSymbol symbolSlot2, IBodyPartSymbol bodyPartSymbol);
        void AddToolSymbol(IEntity Tool);

    }
}
