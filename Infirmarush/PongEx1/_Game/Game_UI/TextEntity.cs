using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1._Game.Game_UI
{
    class TextEntity:GameXEntity,ITextEntity
    {
        protected SpriteFont font;
        protected string text="";
        protected Color colour=Color.Black;
        public void setFont(SpriteFont pSpriteFont)
        {
            font = pSpriteFont;
        }
        public override void draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.DrawString(font, text, entityLocn, colour);
        }
    }
}
