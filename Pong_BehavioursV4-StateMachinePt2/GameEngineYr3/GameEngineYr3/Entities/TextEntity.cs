using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    class TextEntity:GameXEntity, ITextEntity
    {
        //DECLARE a SpriteFont for storing the font that the text entity is using
        protected SpriteFont font;
        //DECLARE a string for storing the text that the text entity is using
        protected string text = "";
        //DECLARE a Color for storing the colour of the text entity
        protected Color colour = Color.Black;

        public string Text { get => text; set => text=value; }

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
            pSpriteBatch.DrawString(font, text, Transform.position, colour);
        }
    }
}
