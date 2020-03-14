using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.Entities;
namespace PongEx1.Collision
{
    class CollisionManager:ICollisionManager, ICollisionSubscriber
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
            //if paddle and ball collide, then return true
            for(int i=0;i<EntityList.Count-1;i++)
            {
                for(int j=i+1;j<EntityList.Count;j++)
                {
                    if (EntityList[i].getHitBox().Intersects(EntityList[j].getHitBox()))
                    {
                        EntityList[i].onCollide((IEntity)EntityList[j]);
                        EntityList[j].onCollide((IEntity)EntityList[i]);
                    }
                }
                
            }
        }
        #endregion
        #region ICollisionSubscriber
        public void Subscribe(ICollidable collidable)
        {
            EntityList.Add(collidable);
        }

        public void Unsubscribe(ICollidable collidable)
        {
            EntityList.Remove(collidable);
        }
        #endregion
        #region ICollisionManager
        public void Update() {
            CollideCheck();
            
        }
        #endregion
    }
}
