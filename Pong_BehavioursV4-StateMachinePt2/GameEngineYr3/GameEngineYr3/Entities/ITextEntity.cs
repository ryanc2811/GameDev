using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    public interface ITextEntity
    {
        /// <summary>
        /// Sets the Sprite font for the Text entity
        /// </summary>
        /// <param name="pSpriteFont"></param>
        void SetFont(SpriteFont pSpriteFont);
        /// <summary>
        /// Stores the current string of the text entity
        /// </summary>
        string Text { get; set; }
    }
}
