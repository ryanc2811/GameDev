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
            //current animation is the first value of the dictionary
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
            //if the animation is already playing, return
            if (Find(animationKey) == currentAnimation)
                return;
            //set current animation
            currentAnimation = Find(animationKey);
            //reset animation current frame
            currentAnimation.CurrentFrame = 0;
            //reset animation timer
            timer = 0;
        }
        /// <summary>
        /// Stops the animation
        /// </summary>
        public void Stop()
        {
            //reset animation timer
            timer = 0;
            //reset the current animation frame
            currentAnimation.CurrentFrame = 0;
        }
        public bool AnimationFinished()
        {
            if (currentAnimation.CurrentFrame >= currentAnimation.FrameCount)
                return true;
            else return false;
        }
        /// <summary>
        /// Updates the animation
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            //add elapsed time to the animation timer
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //reset timer on each frame
            if (timer > currentAnimation.FrameSpeed)
            {
                timer = 0f;
                //add 1 to current frame
                currentAnimation.CurrentFrame++;
                //if animation finished, then reset frame to 0
                if (currentAnimation.CurrentFrame >= currentAnimation.FrameCount)
                    currentAnimation.CurrentFrame = 0;
            }
        }
    }
}
