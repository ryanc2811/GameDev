using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Commands
{
    class RepositionCommand : ICommand
    {
        IAIUser entity;
        Vector2 newPosition;
        Vector2 oldPosition;
        public RepositionCommand(IAIUser pEntity, Vector2 pNewPosition)
        {
            entity = pEntity;
            newPosition = pNewPosition;
        }
        public void Execute()
        {
            oldPosition= entity.Position;
            entity.Position = newPosition;
        }

        public void Undo()
        {
            oldPosition = entity.Position;
            entity.Position = newPosition;
        }
    }
}
