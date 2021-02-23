using GameEngine.Animation_Stuff;
using GameEngine.Collision;
using GameEngine.Entities;
using GameEngine.Input;
using Microsoft.Xna.Framework;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Entities
{
    class TopDownCharacter : GameXEntity, IAnimatedSprite, IAIUser
    {
        /// <summary>
        /// Updates the topdown character
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            //Update the animation manager
            animationManager.Update(gameTime);
            //move character with velocity
            transform.position += transform.velocity;
            transform.velocity = Vector2.Zero;
        }
        /// <summary>
        /// Instantiates and adds animations to animation manager
        /// </summary>
        /// <param name="animations"> collection of animations</param>
        public void AddAnimations(IDictionary<string, IAnimation> animations)
        {
            animationManager = new AnimationManager(animations);
        }
        /// <summary>
        /// Returns the animation manager
        /// </summary>
        /// <returns></returns>
        public IAnimationManager GetAnimationManager()
        {
            return animationManager;
        }
        /// <summary>
        /// Returns the current animation
        /// </summary>
        /// <returns></returns>
        public IAnimation GetCurrentAnimation()
        {
            return animationManager.CurrentAnimation;
        }
    }
}
