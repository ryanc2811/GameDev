using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class BallOutOfBounds : BaseCondition
    {
        public override bool FindOutcome()
        {
            if (owner.Transform.position.X > Kernel.Kernel.SCREENWIDTH)
            {
                return true;
            }
            else if (owner.Transform.position.X < 0)
            {
                return true;
            }
            return false;
        }
    }
}
