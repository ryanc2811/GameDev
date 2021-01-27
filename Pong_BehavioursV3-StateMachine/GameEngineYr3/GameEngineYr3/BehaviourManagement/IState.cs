﻿using GameEngine.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    public interface IState
    {
        /// <summary>
        /// Starts the states transition
        /// </summary>
        void Begin();
        /// <summary>
        /// Exectutes the states behaviour
        /// </summary>
        void Execute();
        /// <summary>
        /// Ends the State transition
        /// </summary>
        void End();

        void ChangeCommand(ICommand newCommand);
        void AddCommandManager(ICommandManager commandManager);
    }
}
