using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using GameEngine.Collision;
using GameEngine.Input;
using GameEngine.Entities;
using GameEngine.Kernel;
namespace Pong.Entities
{
    class Ball : GameXEntity,IAIUser
    {
        public Vector2 Position { get => position; set => position=value; }

        #region Initialise
        //initialise the ball
        public override void Initialise()
        {
            //Initialise Mind

        }
        #endregion

        #region update
        //balls update method
        public override void Update()
        {
        }
        #endregion
    }
}
