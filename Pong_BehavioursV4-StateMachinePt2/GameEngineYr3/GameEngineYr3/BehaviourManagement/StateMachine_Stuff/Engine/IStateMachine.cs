﻿using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement.StateMachine_Stuff
{
    public interface IStateMachine
    {
        /// <summary>
        /// Initiate a new State
        /// </summary>
        /// <param name="state"></param>
        /// <param name="command"></param>
        void ChangeState(int newStateIndex);
        /// <summary>
        /// returns the Current state index
        /// </summary>
        int CurrentStateIndex { get; }
        /// <summary>
        /// Adds the text entity to the statemachine
        /// </summary>
        /// <param name="textEntity"></param>
        void AddStateText(ITextEntity textEntity);
        /// <summary>
        /// Adds a new state to the dictionary
        /// </summary>
        /// <param name="pStateIndex"></param>
        /// <param name="pState"></param>
        void AddState(int pStateIndex,IState pState);
        /// <summary>
        /// Removes a state from the dictionary
        /// </summary>
        /// <param name="pStateEnum"></param>
        void RemoveState(int stateIndex);
    }
}
