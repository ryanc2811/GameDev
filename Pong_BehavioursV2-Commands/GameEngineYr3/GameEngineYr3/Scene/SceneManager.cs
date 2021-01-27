using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Entities;

namespace GameEngine.Scene
{
    class SceneManager:ISceneManager
    {
        #region Variables
        //DECLARE Array to store the entieties from the scene
        public List<IEntity> EntityList;
        //DECLARE Sprite Batch to draw them
        public SpriteBatch spriteBatch;
        #endregion

        #region Contructor
        public SceneManager()
        {
            EntityList = new List<IEntity>();
        }
        #endregion


        #region Add / Remove Entity
        public void AddEntity(IEntity entity)
        {   //add entities to List
            EntityList.Add(entity);
            
        }
        public void removeEntity(IEntity entity)
        {   //remove entities from the List
            EntityList.Remove(entity);

        }
        #endregion

        #region Draw
        public void Draw()
        {
            //draw
            foreach (IEntity entity in EntityList)
            {
                entity.draw(spriteBatch);
            }
  
        }
        #endregion

        #region Update
        public void Update()
        { 
            //update
            foreach (IEntity entity in EntityList)
            {
                entity.Update();
                
            }
            
        }
        #endregion

    }
}
