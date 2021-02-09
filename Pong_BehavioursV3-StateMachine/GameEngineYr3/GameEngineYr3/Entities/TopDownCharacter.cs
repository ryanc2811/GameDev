using GameEngine.Animation_Stuff;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Entities
{
    class TopDownCharacter : GameXEntity, IAnimatedSprite, IAIUser
    {
        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);
            SetPosition(Transform.Position('+', Transform.velocity).X, Transform.Position('+', Transform.velocity).Y);
        }
        public void AddAnimations(IDictionary<string, IAnimation> animations)
        {
            animationManager = new AnimationManager(animations);
        }

        public IAnimationManager GetAnimationManager()
        {
            return animationManager;
        }

        public IAnimation GetCurrentAnimation()
        {
            return animationManager.CurrentAnimation;
        }
    }
}
