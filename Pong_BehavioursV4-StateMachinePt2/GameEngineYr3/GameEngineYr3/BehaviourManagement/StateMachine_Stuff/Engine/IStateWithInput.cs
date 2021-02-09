using GameEngine.Entities;
using GameEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateWithInput
    {
        int HandleInput(object sender, InputEventArgs inputEvent);
    }
}
