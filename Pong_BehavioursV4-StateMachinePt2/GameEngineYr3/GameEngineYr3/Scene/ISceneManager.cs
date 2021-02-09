using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Scene
{
    public interface ISceneManager
    {
        //Draw 
        void Draw(SpriteBatch spriteBatch);
        //Add entity to the array
        void AddEntity(IEntity entity);
        void Initialise();
        //Remove entity from the array
        void removeEntity(IEntity entity);
        //Update
        void Update(GameTime gameTime);
    }
}
