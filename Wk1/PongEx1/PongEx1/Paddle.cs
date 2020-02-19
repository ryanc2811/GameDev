using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class Paddle:PongEntity
    {
        
        public void Update(Vector2 facingDirection)
        {
            entityLocn.Y += facingDirection.Y*10;
            
        }
    }
}
