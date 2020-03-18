using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Game_Engine.Collision
{
    interface ICollisionPublisher
    {
        //Subscribes Collidable objects to the collision manager
        void Subscribe(ICollidable collidable);
        //Unsubscribes Collidable objects to the collision manager
        void Unsubscribe(ICollidable collidable);
    }
}
