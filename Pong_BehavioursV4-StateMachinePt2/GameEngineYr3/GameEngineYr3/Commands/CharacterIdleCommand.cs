using GameEngine.Animation_Stuff;
using Pong.State_Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class CharacterIdleCommand : BaseCommand
    {
        public override void Execute()
        {
            
        }

        /// <summary>
        /// Starts the idle command
        /// </summary>
        public override void StartCommand()
        {
            //Play the idle animation
            ((IAnimatedSprite)owner).GetAnimationManager().Play("idle");
        }
    }
}
