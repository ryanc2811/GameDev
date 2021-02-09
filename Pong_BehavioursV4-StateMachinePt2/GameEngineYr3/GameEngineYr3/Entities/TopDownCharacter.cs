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
        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);
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

        public IAnimationManager GetAnimationManager()
        {
            return animationManager;
        }

        public IAnimation GetCurrentAnimation()
        {
            return animationManager.CurrentAnimation;
        }
        public Rectangle GetHitBox()
        {
            //If the character is not animated then draw using texture from entity class
            if (texture != null)
                return new Rectangle((int)Transform.position.X, (int)Transform.position.Y, texture.Width, texture.Height);
            else if (animationManager!= null)
                return new Rectangle((int)Transform.position.X, (int)Transform.position.Y, GetCurrentAnimation().Texture.Width,GetCurrentAnimation().Texture.Height);
            else
            {
                throw new Exception();
            }
        }
        public override void OnContentLoad()
        {
            
        }
        public void OnCollide(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            //Pass Input data to statemachine
            //stateMachine.HandleInput(this, args);
        }
    }
}
