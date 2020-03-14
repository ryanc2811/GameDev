using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1.Entities;

namespace PongEx1.Scene
{
    class SceneManager:ISceneManager
    {
        
        public List<IEntity> EntityList;
        public SpriteBatch spriteBatch;
      

        public SceneManager()
        {
            EntityList = new List<IEntity>();
        }
        
        public void addEntity(IEntity entity)
        {   //add entities to List
            EntityList.Add(entity);
            
        }
        public void removeEntity(IEntity entity)
        {   //add entities to List
            EntityList.Remove(entity);

        }
        public void Draw()
        {
            //draw
            foreach (IEntity entity in EntityList)
            {
                entity.draw(spriteBatch);
            }
  
        }
       
        public void Update()
        { 
            //update
            foreach (IEntity entity in EntityList)
            {
                entity.Update();
                
            }
            
        }

    }
}
