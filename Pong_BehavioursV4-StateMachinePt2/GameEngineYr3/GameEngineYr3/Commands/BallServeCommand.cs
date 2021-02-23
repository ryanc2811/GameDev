using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class BallServeCommand : BaseCommand
    {
        Vector2 velocity;
        public override void Execute()
        {
            //throw new NotImplementedException();
        }
        public override void StartCommand()
        {
            Random random = new Random();
            //ASSIGN speed value
            float speed = 15;
            //place ball in the centre of the screen
            owner.SetPosition(Kernel.Kernel.SCREENWIDTH / 2, Kernel.Kernel.SCREENHEIGHT / 2);
            //CALCULATE the rotation
            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));

            //Launch ball diagonally
            velocity = new Vector2((float)Math.Sin(rotation), (float)Math.Cos(rotation));
            //Create random number between 1 and 2
            int rnd = random.Next(1, 3);
            //launch the ball in a random direction
            if (rnd == 2)
            {
                velocity.X *= -1;
            }

            velocity.X *= speed;

            owner.SetVelocity(velocity.X, velocity.Y);
        }
    }
}
