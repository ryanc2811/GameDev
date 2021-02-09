using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Entities;
using GameEngine.BehaviourManagement;

namespace GameEngine.Collision
{
     interface ICollidable
    {
        //Returns a hitbox of the collidable object
        Rectangle GetHitBox();
        //Passes Entity that has been collided with
        void OnCollide(IEntity entity);
    }
}
