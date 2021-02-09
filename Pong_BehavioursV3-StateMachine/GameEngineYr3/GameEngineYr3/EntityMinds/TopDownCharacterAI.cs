using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.Collision;
using GameEngine.Input;
using GameEngine.Kernel;
using GameEngine.State_Stuff;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Pong.Commands;
using Pong.EntityMinds;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.EntityMinds
{
    class TopDownCharacterAI : PongAI, ICollidable, IInputListener
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        public TopDownCharacterAI()
        {
            speed = 2;
        }
        public override void Initialise()
        {
            
        }
        public Rectangle GetHitBox()
        {
            //If the character is not animated then draw using texture from entity class
            if (gameObject.GetTexture() != null)
                return new Rectangle((int)gameObject.Transform.position.X, (int)gameObject.Transform.position.Y, gameObject.GetTexture().Width, gameObject.GetTexture().Height);
            else if (((IAnimatedSprite)gameObject).GetAnimationManager() != null)
                return new Rectangle((int)gameObject.Transform.position.X, (int)gameObject.Transform.position.Y, ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Width, ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Height);
            else
            {
                throw new Exception();
            }
        }
        public override void OnContentLoad()
        {
            IAnimationManager animationManager = ((IAnimatedSprite)gameObject).GetAnimationManager();
            stateMachine = new CharacterStateMachine(animationManager);
        }
        public void OnCollide(IAIComponent entity)
        {
            throw new NotImplementedException();
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            keyList = args.PressedKeys;
            velocity = Vector2.Zero;
            //Pass Input data to statemachine
            stateMachine.HandleInput(gameObject, args);

            //If any movement keys are pressed
            if (keyList.Contains(Keys.W))
            {
                velocity.Y -= speed;
            }
            else if (keyList.Contains(Keys.S))
            {
                velocity.Y += speed;
            }
            else if (keyList.Contains(Keys.A))
            {
                velocity.X -= speed;
            }
            else if (keyList.Contains(Keys.D))
            {
                velocity.X += speed;
            }
        }
        public override void Update()
        {
            //Update the state manager
            stateMachine.Update();
            gameObject.SetVelocity(velocity.X, velocity.Y);
        }
    }
}
