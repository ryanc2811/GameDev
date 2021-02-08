using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Commands;
namespace Pong.Commands
{
    class MoveCommand : ICommand
    {
        //DECLARE an IAIUser, called entity for storing a refrence to AI user
        private IAIUser entity;
        /// <summary>
        /// Property for storing movement direction of AI
        /// </summary>
        public Vector2 direction { get; private set; }

        public MoveCommand(IAIUser pEntity, Vector2 pDirection)
        {
            entity = pEntity;
            direction = pDirection;
        }
        /// <summary>
        /// Executes the movement command
        /// </summary>
        public void Execute()
        {
            entity.Position += direction;
        }
        /// <summary>
        /// Undoes the movement command
        /// </summary>
        public void Undo()
        {
            entity.Position -= direction;
        }

        public void StartCommand()
        {
            throw new NotImplementedException();
        }

        public void ExitCommand()
        {
            throw new NotImplementedException();
        }
    }
}
