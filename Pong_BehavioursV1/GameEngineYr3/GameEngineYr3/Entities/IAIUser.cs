using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Entities
{
    public interface IAIUser
    {
        Vector2 Position { get; set; }
        Texture2D GetTexture();

        Vector2 Velocity { get; set; }
    }
}
