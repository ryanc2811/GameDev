using GameEngine.BehaviourManagement;
using GameEngine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.EntityMinds
{
    abstract class PongAI : IAIComponent
    {
        public abstract void SetEntity(IEntity entity);

        public abstract void Update();
    }
}
