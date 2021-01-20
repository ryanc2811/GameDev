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
    /// Class for the symbol entity
    /// </summary>
    class Symbol : GameXEntity, ISymbol
    {
        /// <summary>
        /// Gets and sets the symbol type of the symbol
        /// </summary>
        public SymbolType SymbolType { get; set; }
        /// <summary>
        /// gets and sets the patient number that relates to the symbol
        /// </summary>
        public PatientNum Patient { get; set; }
        /// <summary>
        /// gets and sets the boolean that checks if the symbols is being used in the handbook
        /// </summary>
        public bool usedInHandbook { get; set; }
        //DECLARE a Vector2 for storing the start position of the Symbol
        private Vector2 startPos;
        /// <summary>
        /// Sets the start position of the symbol
        /// </summary>
        /// <param name="pStartPos"></param>
        public void SetStartPos(Vector2 pStartPos)
        {
            startPos = pStartPos;
        }
        /// <summary>
        /// sets the symbol to be active/inactive
        /// </summary>
        /// <param name="isActive"></param>
        public void SetActive(bool isActive)
        {
            //if the symbol is not active set the position off screen, else set the position to the start position
            if (!isActive)
                setPosition(1111, 1111);
            else
                entityLocn = startPos;
        }
        
    }
    /// <summary>
    /// Enun for the Symbol type
    /// </summary>
    public enum SymbolType
    {
        BodyPart,
        Symptom
    }
}
