using GameEngine.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class BallServed : BaseCondition
    {
        public override bool FindOutcome()
        {
            return true;
        }
    }
}
