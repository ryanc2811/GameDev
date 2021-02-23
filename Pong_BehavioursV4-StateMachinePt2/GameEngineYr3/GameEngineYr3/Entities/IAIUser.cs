using GameEngine.Utilities;
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
        //Property for AIUsers Transform
        Transform Transform { get;}
        //Setter for Position
        void SetPosition(float x, float y);
        void SetVelocity(float x, float y);
        //Getter for Getting AIUsers Texture
        Texture2D GetTexture();  
        string Tag { get; }
    }
}
