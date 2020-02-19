using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1
{
    class AI : Paddle
    {
        private IBall ball;
        private Vector2 ballPos;
        private float speed=20f;
        public AI(IBall pBall)
        {
            ball = pBall;
            ballPos = ball.getBallPos();
        }
        public override void Update()
        {
            ballPos = ball.getBallPos();
            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (entityLocn.Y < 0)
            {

                entityLocn.Y = 0;

            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (entityLocn.Y >= Kernel.ScreenHeight - 150)
            {

                entityLocn.Y = Kernel.ScreenHeight - 150;

            }
            if (ballPos.Y > entityLocn.Y && ballPos.X > Kernel.ScreenWidth/2)
            {
                entityLocn += new Vector2(0, speed);
            }
            if (ballPos.Y < entityLocn.Y && ballPos.X > Kernel.ScreenWidth / 2)
            {
                entityLocn += new Vector2(0, -speed);
            }
        }
    }
}
