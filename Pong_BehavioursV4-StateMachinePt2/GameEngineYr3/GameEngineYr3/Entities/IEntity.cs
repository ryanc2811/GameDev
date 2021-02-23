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
   public interface IEntity
    {
        //UID property
        string id { get; set; }
        string Tag { get; set; }
        //store texture for entity
        void SetTexture(Texture2D texture2D);
        /// <summary>
        /// Returns the entities texture
        /// </summary>
        /// <returns></returns>
        Texture2D GetTexture();
        /// <summary>
        /// Returns the transform of the entity
        /// </summary>
        Transform Transform { get; }
        //return Position value
        Vector2 GetPosition();
        /// <summary>
        /// Sets the position of the entity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetPosition(float x, float y);
        /// <summary>
        /// sets the velocity of the entity
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        void SetVelocity(float x, float y);
        //initialise entity
        void Initialise();
        //pass the spriteBatch
        void draw(SpriteBatch spriteBatch);
        /// <summary>
        /// Called once content has been loaded
        /// </summary>
        void OnContentLoad();
        //Update method
        void Update(GameTime gameTime);
    }
}
