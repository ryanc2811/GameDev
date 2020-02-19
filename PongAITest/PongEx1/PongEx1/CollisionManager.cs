using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class CollisionManager:ICollisionManager, ICollisionSubscriber
    {

        private List<ICollidable> EntityList;
        

        public CollisionManager()
        {
            EntityList = new List<ICollidable>();
        }

        
        public void CollideCheck()
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

        public void Subscribe(ICollidable collidable)
        {
            EntityList.Add(collidable);
        }

        public void Unsubscribe(ICollidable collidable)
        {
            EntityList.Remove(collidable);
        }

        public void Update() {
            CollideCheck();
            
        }
    }
}
