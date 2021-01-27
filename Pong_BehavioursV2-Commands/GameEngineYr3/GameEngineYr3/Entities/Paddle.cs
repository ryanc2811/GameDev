using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Collision;
using GameEngine.Input;
using GameEngine.Entities;
using GameEngine.Kernel;
namespace Pong.Entities
{
    class Paddle:GameXEntity,IAIUser
    {
        #region variables
        public Vector2 Position { get => position; set => position=value; }

        #endregion

        #region Initialize
        //initialise the paddle
        public override void Initialise()
        {
           
        }
        #endregion

        #region properties
        public int Height()
        {
            //return height of the texture, witch is height of the paddle
            return texture.Height;
        }
        public int Width()
        {
            //return width of the texture, witch is width of the paddle
            return texture.Width;
        }
        #endregion

        #region OnCollide
        public void OnCollide(IEntity entity)
        {
            //do nothing
        }
        #endregion

        #region Update
        public override void Update()
        {
            
        }
        #endregion
    }

}

