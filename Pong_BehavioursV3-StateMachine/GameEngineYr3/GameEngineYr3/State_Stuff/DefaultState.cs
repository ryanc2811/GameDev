using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.BehaviourManagement;
using GameEngine.Commands;
using GameEngine.Input;

namespace GameEngine.State_Stuff
{
    class DefaultState : IState
    {
        ICommand currentCommand;
        ICommandManager commandManager;
        public void AddCommandManager(ICommandManager pCommandManager)
        {
            commandManager = pCommandManager;
        }

        public void Begin()
        {
            if (currentCommand != null)
                commandManager.ExecuteCommand(currentCommand);
        }

        public void ChangeCommand(ICommand pNewCommand)
        {
            currentCommand = pNewCommand;
        }

        public void End()
        {
            //throw new NotImplementedException();
        }

        public void Execute()
        {
            //throw new NotImplementedException();
        }

        public IState HandleInput(IAIComponent AI, InputEventArgs inputEvent)
        {
            throw new NotImplementedException();
        }

        public int StateIndex()
        {
            throw new NotImplementedException();
        }
    }
}
