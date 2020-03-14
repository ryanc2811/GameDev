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
    public interface ICollidable
    {
        Rectangle getHitBox();
        void onCollide(IEntity entity);
    }
}
