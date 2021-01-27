using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Commands
{
    class MoveCommand : ICommand
    {
        private Vector2 direction;
        private IAIUser entity;
        public MoveCommand(IAIUser pEntity, Vector2 pDirection)
        {
            entity = pEntity;
            direction = pDirection;
        }
        public void Execute()
        {
            entity.Position += direction;
        }
        public void Undo()
        {
            entity.Position -= direction;
        }
    }
}
