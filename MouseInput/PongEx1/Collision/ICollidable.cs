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
     interface ICollidable
    {
        //Returns a hitbox of the collidable object
        Rectangle getHitBox();
        //Passes Entity that has been collided with
        void onCollide(IEntity entity);
    }
}
