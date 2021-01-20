using PongEx1.Entities._Symbols;
using PongEx1.Entities.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Hand_Book
{
    /// <summary>
    /// interface for the handbook, which is used to display the symbols that will be used in the game
    /// </summary>
    public interface IHandBook
    {
        /// <summary>
        /// Add a 
        /// </summary>
        /// <param name="symbolType"></param>
        /// <param name="symbolButton"></param>
        void AddSymbolButton(SymbolType symbolType, IButton symbolButton);
        /// <summary>
        /// adds the symbol handler, which contains a reference to all the symbols in the game
        /// </summary>
        /// <param name="symbolHandler"></param>
        void AddSymbolHandler(ISymbolHandler symbolHandler);
        /// <summary>
        /// adds the button that sets the handbook active and inactive
        /// </summary>
        /// <param name="handBookButton"></param>
        void AddHandBookButton(IButton symbolButton);
        /// <summary>
        /// Adds the illness calculator, which calculates the tool that the player must use with a list of symptoms and body parts
        /// </summary>
        /// <param name="illnessCalculator"></param>
        void AddIllnessCalculator(IIllnessCalculator illnessCalculator);
        /// <summary>
        /// adds the button that resets the calculator to the handbook
        /// </summary>
        /// <param name="resetButton"></param>
        void AddResetButton(IButton resetButton);
    }
}
