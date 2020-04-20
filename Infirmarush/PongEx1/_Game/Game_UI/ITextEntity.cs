using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Interface for the Text Entity
    /// </summary>
    public interface ITextEntity
    {
        //Sets the Sprite font for the Text entity
        void SetFont(SpriteFont pSpriteFont);
    }
}
