using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Animation_Stuff
{
    public interface IAnimation
    {
        /// <summary>
        /// Stores the texture of the animation
        /// </summary>
        Texture2D Texture { get; }
        /// <summary>
        /// stores the frame count
        /// </summary>
        int FrameCount { get; set; }
        /// <summary>
        /// stores the current frame of the animation
        /// </summary>
        int CurrentFrame { get; set; }
        /// <summary>
        /// returns the height of the texture
        /// </summary>
        int FrameHeight { get; }
        /// <summary>
        /// returns the width of a single texture within the sprite strip
        /// </summary>
        int FrameWidth { get; }
        /// <summary>
        /// stores the speed of each frame
        /// </summary>
        float FrameSpeed { get; set; }
        /// <summary>
        /// boolean for checking if the animation should loop
        /// </summary>
        bool IsLooping { get; set; }

    }
}
