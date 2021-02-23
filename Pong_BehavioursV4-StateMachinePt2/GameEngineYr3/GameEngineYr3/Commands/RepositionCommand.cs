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
    class RepositionCommand : ICommand
    {
        //DECLARE an IAIUser called entity, for storing a reference to the AIUser
        private IAIUser entity;
        //DECLARE a Vector 2 called newPosition, for storing the position that the entity will move to
        private Vector2 newPosition;
        //DECLARE a Vector 2 called oldPosition, for storing the last position of the entity
        private Vector2 oldPosition;
        public RepositionCommand(IAIUser pEntity, Vector2 pNewPosition)
        {
            entity = pEntity;
            newPosition = pNewPosition;
        }
        /// <summary>
        /// Execute the command
        /// </summary>
        public void Execute()
        {
            oldPosition = entity.Transform.position;
            entity.SetPosition(newPosition.X, newPosition.Y);
        }

        public void ExitCommand()
        {
            throw new NotImplementedException();
        }

        public void SetOwner(IAIUser owner)
        {
            throw new NotImplementedException();
        }

        public void StartCommand()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Undo the command
        /// </summary>
        public void Undo()
        {
            oldPosition = entity.Transform.position;
            entity.SetPosition(newPosition.X,newPosition.Y);
        }
    }
}
