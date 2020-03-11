using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    public interface ICollidable
    {
        Rectangle getHitBox();
        void onCollide(IEntity entity);
    }
}
