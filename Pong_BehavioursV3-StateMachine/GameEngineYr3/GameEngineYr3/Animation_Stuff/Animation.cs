using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Animation_Stuff
{
    class Animation : IAnimation
    {
        public Animation(Texture2D texture, int frameCount)
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;
            FrameSpeed = 0.2f;
        }
        /// <summary>
        /// Stores the texture of the animation
        /// </summary>
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// stores the frame count
        /// </summary>
        public int FrameCount { get; set; }
        /// <summary>
        /// stores the current frame of the animation
        /// </summary>
        public int CurrentFrame { get; set ; }

        /// <summary>
        /// returns the height of the texture
        /// </summary>
        public int FrameHeight { get { return Texture.Height; } }
        /// <summary>
        /// returns the width of a single texture within the sprite strip
        /// </summary>
        public int FrameWidth { get { return Texture.Width / FrameCount; } }
        /// <summary>
        /// stores the speed of each frame
        /// </summary>
        public float FrameSpeed { get ; set; }
        /// <summary>
        /// boolean for checking if the animation should loop
        /// </summary>
        public bool IsLooping { get; set ; }

    }
}
