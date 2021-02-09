using GameEngine.Entities;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine
{
    public interface IStateWithInput
    {
        int HandleInput(IAIUser entity, InputEventArgs inputEvent);
    }
}
