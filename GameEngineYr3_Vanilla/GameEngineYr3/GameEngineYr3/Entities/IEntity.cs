using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Entities
{
   public interface IEntity
    {
        //UID property
        string id { get; set; }

        //store texture for entity
        void setTexture(Texture2D texture2D);
        //store position of entity
        void setPosition(float x, float y);
        //return Position value
        Vector2 getPosition();
        //initialise entity
        void Initialise();
        //pass the spriteBatch
        void draw(SpriteBatch spriteBatch);
        //Update method
        void Update();
    }
}
