using GameEngine.Animation_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateWithAnimation
    {
        void SetAnimator(IAnimationManager animationManager);
    }
}
