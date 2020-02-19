using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongEx1
{
    
    abstract class PongEntity : Game
    {
        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        public Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        public Texture2D texture;

        public PongEntity()
        {

        }
        public void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
            
        }
        //public void collision()
        //{

        //}
        public void setTexture(Texture2D pTexture)
        {
            texture = pTexture;
        }
        public void draw(SpriteBatch pSpriteBatch)
        {
            pSpriteBatch.Draw(texture, entityLocn, Color.AntiqueWhite);
            
        }

        public virtual void Update()
        {

        }
    }


  

}
