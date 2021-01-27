using GameEngine.BehaviourManagement;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using GameEngine.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.EntityMinds
{
    class PongAI : AIComponent
    {
        protected IAIUser gameObject;
        protected IStateMachine stateMachine;
        protected Vector2 velocity;
        protected float speed;
        public override void Update()
        {
            //DO NOTHING
        }
        public override void SetAIUser(IAIUser aiUser)
        {
            gameObject = aiUser;
        }
        public override void Initialise()
        {
            //DO NOTHING
        }

        public override Vector2 GetPosition()
        {
            return gameObject.Position;
        }

        public override int Height()
        {
            return gameObject.GetTexture().Height;
        }

        public override int Width()
        {
            return gameObject.GetTexture().Width;
        }

        public override void OnContentLoad()
        {
            
        }
    }
}
