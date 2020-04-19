using Microsoft.Xna.Framework;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    class Symbol : GameXEntity, ISymbol
    {
        public SymbolType SymbolType { get; set; }
        public PatientNum Patient { get; set; }
        public bool usedInHandbook { get; set; }
        private Vector2 startPos;
        public void SetStartPos(Vector2 pStartPos)
        {
            startPos = pStartPos;
        }
        public void SetActive(bool isActive)
        {
            if (!isActive)
                setPosition(1111, 1111);
            else
                entityLocn = startPos;
        }
        
    }
    public enum SymbolType
    {
        BodyPart,
        Symptom
    }
}
