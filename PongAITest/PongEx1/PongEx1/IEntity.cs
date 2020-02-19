using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
   public interface IEntity
    {
        //UID property
        string id { get; set; }
        void setTexture(Texture2D texture2D);
        void setPosition(float x, float y);
        void Initialise();
        void draw(SpriteBatch spriteBatch);
        void Update();
    }
}
