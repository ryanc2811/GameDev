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
        event Action UpdateMind;
        //Property for AIUsers Position
        Vector2 Position { get; set; }
        //Property for AIUsers Velocity
        Vector2 Velocity { get; set; }
        //Getter for Getting AIUsers Texture
        Texture2D GetTexture();
    }
}
