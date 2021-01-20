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
        /// <summary>
        /// Calculate which tool symbol shall be returned with the given parameters
        /// </summary>
        /// <param name="symbolSlot1"></param>
        /// <param name="symbolSlot2"></param>
        /// <param name="bodyPartSymbol"></param>
        /// <returns>Tool Entity</returns>
        IEntity CalculateIllness(ISymptomSymbol symbolSlot1, ISymptomSymbol symbolSlot2, IBodyPartSymbol bodyPartSymbol);
        /// <summary>
        /// Add the tool symbol to the illness calculator
        /// </summary>
        /// <param name="Tool"></param>
        void AddToolSymbol(IEntity Tool);
    }
}
