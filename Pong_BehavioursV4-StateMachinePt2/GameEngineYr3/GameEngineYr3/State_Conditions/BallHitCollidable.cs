using GameEngine.BehaviourManagement;
using GameEngine.Collision;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class BallHitCollidable : BaseCondition, ICollidable
    {
        bool canBounce = false;
        bool colliding = false;
        public override bool FindOutcome()
        {
            if (owner.Transform.position.Y > Kernel.Kernel.SCREENHEIGHT)
            {
                canBounce = true;
            }
            else if (owner.Transform.position.Y < 0)
            {
                canBounce = true;
            }
            else if (owner.Transform.position.Y > 0 && owner.Transform.position.Y > Kernel.Kernel.SCREENHEIGHT&&!colliding)
            {
                canBounce = false;
            }
            return canBounce;
        }

        public Rectangle GetHitBox()
        {
            throw new NotImplementedException();
        }

        public void OnCollide(IAIComponent entity)
        {
            canBounce = true;
            colliding = true;
        }
        public override void ExitCondition()
        {
            canBounce = false;
            colliding = false;
        }
    }
}
