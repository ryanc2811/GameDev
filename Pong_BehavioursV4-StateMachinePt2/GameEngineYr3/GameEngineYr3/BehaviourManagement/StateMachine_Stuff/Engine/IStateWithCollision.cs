using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateWithCollision
    {
        Rectangle GetHitBox();
        void HandleCollision(IAIComponent entity);
        Action<IAIComponent> CollisionEvent { get; set; }
    }
}
