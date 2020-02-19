using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class Ball : PongEntity
    {
        private int speed = 10;
        //DECLARE integer for storing the facing direction of the ball(1=moving right, -1=moving left), Name it facingDirection
        private int facingDirection = 1;

        private int hitEdgeNum = 0;

        public override void Update()
        {
            
            //move the ball
            entityLocn.X += speed * facingDirection;
            if (entityLocn.X > 1550)
            {
                hitEdgeNum += 1;
                speed = speed + 3;
                facingDirection = -1;

            }
            else if (entityLocn.X < 0)
            {
                hitEdgeNum += 1;
                speed = speed + 3;
                facingDirection = 1;

            }
            else if (hitEdgeNum == 3)
            {
                speed = 0;
            }
        }
    }
}
