using GameEngine.Animation_Stuff;
using GameEngine.BehaviourManagement;
using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.Commands;
using GameEngine.Input;
using GameEngine.State_Conditions;
using GameEngine.Transitions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Stuff
{
    class PaddleMoveState : BaseState, IStateWithCollision,IStateWithInput
    {
        //DECLARE an Action for handling the input event
        private Action<object, InputEventArgs> inputEvent;
        //DECLARE an Action for getting and setting the input event
        public Action<object, InputEventArgs> InputEvent { get => inputEvent; set => inputEvent = value; }

        private Action<IAIComponent> collisionEvent;
        public Action<IAIComponent> CollisionEvent { get => collisionEvent; set => collisionEvent = value; }

        /// <summary>
        /// Creates and returns a new hitbox using the entities texture
        /// </summary>
        /// <returns></returns>
        public Rectangle GetHitBox()
        {
            //If the character is not animated then draw using texture from entity class
            if (owner.GetTexture() != null)
                return new Rectangle((int)owner.Transform.position.X, (int)owner.Transform.position.Y, owner.GetTexture().Width, owner.GetTexture().Height);
            else if (((IAnimatedSprite)owner).GetAnimationManager() != null)
                return new Rectangle((int)owner.Transform.position.X, (int)owner.Transform.position.Y,
                    ((IAnimatedSprite)owner).GetCurrentAnimation().Texture.Width, ((IAnimatedSprite)owner).GetCurrentAnimation().Texture.Height);
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Invokes the collision event
        /// </summary>
        /// <param name="entity"></param>
        public void HandleCollision(IAIComponent entity)
        {
            collisionEvent?.Invoke(entity);
        }

        /// <summary>
        /// Sets all the commands in the commands array
        /// </summary>
        public override void SetCommands()
        {
            commands = new BaseCommand[]
            {
                new PaddleMoveCommand()
            };
        }
        /// <summary>
        /// Sets all the transitions in the transitions array
        /// </summary>
        public override void SetTransitions()
        {
            transitions = new Transition[]
            {
                new Transition("ServeToMove",new PaddleStopped(),
                (int)PaddleState.Idle, StateIndex(),0)
            };
        }
        /// <summary>
        /// Returns the character state as an integer
        /// </summary>
        /// <returns></returns>
        public override int StateIndex()
        {
            return (int)PaddleState.Move;
        }

        public void HandleInput(object sender, InputEventArgs args)
        {
            inputEvent?.Invoke(sender,args);
        }
    }
}
