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
        //DECLARE boolean called gotInput, for flagging when input has been taken
        bool gotInput = false;
        private IList<Keys> previousKeyList= new List<Keys>();
        bool stateChange = false;
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
                return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, gameObject.GetTexture().Width, gameObject.GetTexture().Height);
            else if (((IAnimatedSprite)gameObject).GetAnimationManager() != null)
                return new Rectangle((int)gameObject.Position.X, (int)gameObject.Position.Y, ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Width, ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Height);
            else
            {
                throw new Exception();
            }
        }
        public override void OnContentLoad()
        {
            ////ADD CHARACTER STATES TO STATEMACHINE
            //stateMachine.AddState(States.DEFAULT, new CharacterIdleState(((IAnimatedSprite)gameObject).GetAnimationManager()));
            //stateMachine.AddState(States.MOVING, new CharacterMoveState(((IAnimatedSprite)gameObject).GetAnimationManager()));
            ////SET DEFAULT STATE
            //stateMachine.ChangeState(States.DEFAULT, new RepositionCommand(gameObject, GetPosition()));
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
            stateMachine.HandleInput(this, args);

            //If any movement keys are pressed
            if (keyList.Contains(Keys.W))
            {
                velocity.Y -= speed;
            }
            else if (keyList.Contains(Keys.S) & !previousKeyList.Contains(Keys.S))
            {
                velocity.Y += speed;
            }
            else if (keyList.Contains(Keys.A) & !previousKeyList.Contains(Keys.A))
            {
                velocity.X -= speed;
            }
            else if (keyList.Contains(Keys.D) & !previousKeyList.Contains(Keys.D))
            {
                velocity.X += speed;
            }
            //Store reference to old keylist
            previousKeyList = keyList;
        }
        public override void Update()
        {
            ////if the gameObject reaches the bottom of the screen, stop the Y from decreasing further
            //if (gameObject.Position.Y < ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Width)
            //{
            //    stateMachine.ChangeState(States.DEFAULT, new RepositionCommand(gameObject, new Vector2(gameObject.Position.X, ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Width)));
            //}
            ////if the gameObject reaches the top of the screen, then stop the y from increasing further
            //else if (gameObject.Position.Y >= Kernel.SCREENHEIGHT- ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Height)
            //{
            //    stateMachine.ChangeState(States.DEFAULT, new RepositionCommand(gameObject, new Vector2(gameObject.Position.X, Kernel.SCREENHEIGHT- ((IAnimatedSprite)gameObject).GetCurrentAnimation().Texture.Height)));
            //}

            //Update the state manager
            stateMachine.Update();
        }
    }
}
