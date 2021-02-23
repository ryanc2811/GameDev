using GameEngine.BehaviourManagement;
using GameEngine.Collision;
using GameEngine.Sound_Stuff;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Commands
{
    class BallBounceCommand : BaseCommand, ICollidable
    {
        //DECLARE float for the max angle of the ball's bounce
        float maxAngle = 45f;

        Vector2 velocity;

        float speed = 15;
        public override void Execute()
        {
            if (owner.Transform.position.Y >= Kernel.Kernel.SCREENHEIGHT - 50 || owner.Transform.position.Y < 0)
            {
                velocity.Y *= -1;
                ((ISoundEmitter)owner).GetSoundManager().Play("bounce", 1f);
            }
            owner.SetVelocity(velocity.X, velocity.Y);
        }
        public Rectangle GetHitBox()
        {
            throw new NotImplementedException();
        }

        public void OnCollide(IAIComponent entity)
        {
        https://gamedev.stackexchange.com/questions/4253/in-pong-how-do-you-calculate-the-balls-direction-when-it-bounces-off-the-paddl 
              //create a variable that stores the y position of the ball when the collision occurs
            float onCollideY = owner.Transform.position.Y;
            //store the y of the ball in relation to the paddle
            float onCollideRelativeY = entity.GetAIUser().Transform.position.Y - onCollideY;
            float onCollideNormalisedY = onCollideRelativeY / (entity.GetAIUser().GetTexture().Height / 2);
            //create a ball angle variable
            float ballAngle = onCollideNormalisedY * (maxAngle * (float)Math.PI / 180);

            //update the Y position with the new ball angle variable
            velocity.Y = speed * -(float)Math.Sin(ballAngle);
            if (speed < 30)
                //each time a paddle collides with a ball, add 3 to the speed
                speed += 3;
            //if the entity that collides with the ball is an AI
            if (entity.GetAIUser().Tag == "LeftPaddle")
            {
                //add the ball angle variable to the velocity on the x axis
                velocity.X = speed * (float)Math.Cos(ballAngle);
            }
            else if (entity.GetAIUser().Tag == "RightPaddle")
            {
                //add the ball angle variable to the velocity on the x axis
                velocity.X = speed * -(float)Math.Cos(ballAngle);
            }

            owner.SetVelocity(velocity.X, velocity.Y);
            ((ISoundEmitter)owner).GetSoundManager().Play("bounce", 1f);
        }

        public override void StartCommand()
        {
            velocity = owner.Transform.velocity;
            speed = 15;
        }
    }
}
