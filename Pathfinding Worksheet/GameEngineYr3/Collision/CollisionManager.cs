using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Entities;
namespace GameEngine.Collision
{
    class CollisionManager:ICollisionManager, ICollisionPublisher
    {
        #region Datamembers
        //DECLARE an IList of type ICollidable for storing a collection of collidable Entities, call it EntityList
        private IList<ICollidable> EntityList;
        #endregion

        #region Constructor
        public CollisionManager()
        {
            //INSTANTIATE EntityList
            EntityList = new List<ICollidable>();
        }
        #endregion

        #region CollisionManagement
        private void CollideCheck()
        {
            
            for(int i=0;i<EntityList.Count-1;i++)
            {
                for(int j=i+1;j<EntityList.Count;j++)
                {
                    //if entities hitbox inside EntityList intersect with eachother 
                    if (EntityList[i].getHitBox().Intersects(EntityList[j].getHitBox()))
                    {
                        //pass a reference of the 2nd entity to the first entity
                        EntityList[i].onCollide((IEntity)EntityList[j]);
                        //pass a reference of the first entity to the 2nd entity
                        EntityList[j].onCollide((IEntity)EntityList[i]);
                    }
                }
                
            }
        }
        #endregion
        #region ICollisionSubscriber
        public void Subscribe(ICollidable collidable)
        {
            //Add Collidable object to the Collidable Entity List
            EntityList.Add(collidable);
        }

        public void Unsubscribe(ICollidable collidable)
        {
            //Remove Collidable object to the Collidable Entity List
            EntityList.Remove(collidable);
        }
        #endregion
        #region ICollisionManager
        public void Update()
        {
            //Check for collisions between collidable objects
            CollideCheck();
        }
        #endregion
    }
}
