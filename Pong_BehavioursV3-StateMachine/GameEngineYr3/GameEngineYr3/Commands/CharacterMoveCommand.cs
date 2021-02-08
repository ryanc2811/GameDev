using GameEngine.BehaviourManagement.StateMachine;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class CharacterMoveCommand : BaseCommand<CharacterStateMachine>
    {
        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public override void ExitCommand()
        {
            throw new NotImplementedException();
        }

        public override void StartCommand()
        {
            throw new NotImplementedException();
        }

        public override void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
