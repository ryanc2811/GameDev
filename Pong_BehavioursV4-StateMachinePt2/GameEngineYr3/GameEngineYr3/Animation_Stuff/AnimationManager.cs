using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Animation_Stuff
{

    class AnimationManager : IAnimationManager
    {
        //DECLARE an IAnimation for storing a refrence to the current animation
        private IAnimation currentAnimation;
        //DECLARE an IDictionary for storing the all the animations that belong to a sprite with a string key
        private IDictionary<string, IAnimation> animations;
        //DECLARE a float, called timer, for storing the elasped time of the animation
        private float timer;
        /// <summary>
        /// Getter for the current animation
        /// </summary>
        public IAnimation CurrentAnimation { get { return currentAnimation; } private set { currentAnimation = value; } }
        
        
        public AnimationManager(IDictionary<string, IAnimation> pAnimations)
        {
            animations = pAnimations;
            currentAnimation = animations.First().Value;
        }
        /// <summary>
        /// Draws the animation
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        /// <param name="position"></param>
        public void Draw(SpriteBatch pSpriteBatch, Vector2 position)
        {
            pSpriteBatch.Draw(currentAnimation.Texture,
                       position,
                       new Rectangle(currentAnimation.CurrentFrame * currentAnimation.FrameWidth,
                                     0,
                                     currentAnimation.FrameWidth,
                                     currentAnimation.FrameHeight),
                       Color.White);
        }

        /// <summary>
        /// Finds and returns an animation with the passed animation key
        /// </summary>
        /// <param name="animationKey"></param>
        /// <returns></returns>
        private IAnimation Find(string animationKey)
        {
            return animations[animationKey];
        }
        /// <summary>
        /// Starts the animation
        /// </summary>
        /// <param name="animationKey"></param>
        public void Play(string animationKey)
        {
            if (Find(animationKey) == currentAnimation)
                return;

            currentAnimation = Find(animationKey);
            currentAnimation.CurrentFrame = 0;
            timer = 0;
        }
        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop()
        {
            timer = 0;
            currentAnimation.CurrentFrame = 0;
        }
        /// <summary>
        /// Updates the animation
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > currentAnimation.FrameSpeed)
            {
                timer = 0f;

                currentAnimation.CurrentFrame++;

                if (currentAnimation.CurrentFrame >= currentAnimation.FrameCount)
                    currentAnimation.CurrentFrame = 0;
            }
        }
    }
}
