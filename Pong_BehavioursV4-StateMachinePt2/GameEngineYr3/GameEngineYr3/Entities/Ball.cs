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
using GameEngine.Animation_Stuff;

namespace Pong.Entities
{
    class Ball : GameXEntity,IAIUser, IAnimatedSprite
    {
        
        #region Initialise
        //initialise the ball
        public override void Initialise()
        {
            //Initialise Mind

        }
        #endregion

        #region update
        //balls update method
        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);
        }
        #endregion
        /// <summary>
        /// Add list of animations to entity and instantiate animation manager
        /// </summary>
        /// <param name="animations"></param>
        public void AddAnimations(IDictionary<string, IAnimation> animations)
        {
            animationManager = new AnimationManager(animations);
        }
        /// <summary>
        /// Getter for animation manager
        /// </summary>
        /// <returns></returns>
        public IAnimationManager GetAnimationManager()
        {
            return animationManager;
        }
        /// <summary>
        /// getter for current Animation
        /// </summary>
        /// <returns></returns>
        public IAnimation GetCurrentAnimation()
        {
            return animationManager.CurrentAnimation;
        }
    }
}
