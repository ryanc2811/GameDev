using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace GameEngine.Entities
{
    abstract class Entity:IEntity
    {
        //UID property
        public abstract string id { get; set; }

        //store texture for entity
        public abstract void SetTexture(Texture2D texture2D);
        //store position of entity
        public abstract Transform Transform { get; }
        public abstract string Tag { get; set; }

        //pass the spriteBatch
        public abstract void draw(SpriteBatch spriteBatch);
        //initialise entity
        public abstract void Initialise();
        //Update method
        public abstract void Update(GameTime gameTime);

        //return Position value
        public abstract Vector2 GetPosition();

        public abstract Texture2D GetTexture();

        public abstract void SetPosition(float x, float y);

        public abstract void SetVelocity(float x, float y);

        public abstract void OnContentLoad();
    }
}
