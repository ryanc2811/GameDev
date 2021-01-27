using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Animation_Stuff
{
    public interface IAnimationManager
    {
        /// <summary>
        /// Starts the animation with the passed animation key
        /// </summary>
        /// <param name="animationKey"></param>
        void Play(string animationKey);
        /// <summary>
        /// Stops the current animation
        /// </summary>
        void Stop();
        /// <summary>
        /// Draws the current animation
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="position"></param>
        void Draw(SpriteBatch spriteBatch,Vector2 position);
        /// <summary>
        /// Updates the animaiton
        /// </summary>
        /// <param name="gameTime"></param>
        void Update(GameTime gameTime);
        /// <summary>
        /// returns the current animation
        /// </summary>
        IAnimation CurrentAnimation { get;}
    }
}
