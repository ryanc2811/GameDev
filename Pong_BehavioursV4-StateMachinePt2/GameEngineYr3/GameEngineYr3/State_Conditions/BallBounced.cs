using GameEngine.Animation_Stuff;
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
    class BallBounced : BaseCondition
    {
        public override bool FindOutcome()
        {
            //if (((IAnimatedSprite)owner).GetAnimationManager().AnimationFinished())
            //{
            //    return true;
            //}
            //else
            //    return false;
            return true;
        }
    }
}
