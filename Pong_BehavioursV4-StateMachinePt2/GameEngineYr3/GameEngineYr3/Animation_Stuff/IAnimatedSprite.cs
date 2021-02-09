using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Animation_Stuff
{
    public interface IAnimatedSprite
    {
        /// <summary>
        /// Sets animations
        /// </summary>
        /// <param name="animations"></param>
        void AddAnimations(IDictionary<string,IAnimation> animations);
        /// <summary>
        /// Getter for animation manager
        /// </summary>
        /// <returns></returns>
        IAnimationManager GetAnimationManager();
        /// <summary>
        /// Getter for active animation
        /// </summary>
        /// <returns></returns>
        IAnimation GetCurrentAnimation();
    }
}
