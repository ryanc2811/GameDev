using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Class for Text entities
    /// </summary>
    class TextEntity:GameXEntity,ITextEntity
    {
        //DECLARE a SpriteFont for storing the font that the text entity is using
        protected SpriteFont font;
        //DECLARE a string for storing the text that the text entity is using
        protected string text="";
        //DECLARE a Color for storing the colour of the text entity
        protected Color colour=Color.Black;
        /// <summary>
        /// Sets the SpriteFont the passed value
        /// </summary>
        /// <param name="pSpriteFont"></param>
        public void SetFont(SpriteFont pSpriteFont)
        {
            font = pSpriteFont;
        }
        /// <summary>
        /// Draws the String using the sprite batch
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public override void draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.DrawString(font, text, entityLocn, colour);
        }
    }
}
