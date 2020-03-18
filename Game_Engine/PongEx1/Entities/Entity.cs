using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace PongEx1.Entities
{
    abstract class Entity:IEntity
    {
        //UID property
        public virtual string id { get; set; }

        //store texture for entity
        public abstract void setTexture(Texture2D texture2D);
        //store position of entity
        public abstract void setPosition(float x, float y);
       
        //pass the spriteBatch
        public abstract void draw(SpriteBatch spriteBatch);
        //initialise entity
        public abstract void Initialise();
        //Update method
        public abstract void Update();

        //return Position value
        public abstract Vector2 getPosition();
        
    }
}
