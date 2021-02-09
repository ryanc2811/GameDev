using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Utilities
{
    public struct Transform
    {
        public Vector2 position;
        public Vector2 velocity;

        public Transform(Vector2 position, Vector2 velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }

        public Vector2 Position (char pOperator, Vector2 newVector)
        {
            switch (pOperator)
            {
                case '+':
                    position += newVector;
                    Console.WriteLine(position);
                    return position;
                case '-':
                    position -= newVector;
                    return position;
                default: return Vector2.Zero;
            }
        }
        public Vector2 Velocity(char pOperator, Vector2 newVector)
        {
            switch (pOperator)
            {
                case '+':
                    return velocity += newVector;
                case '-':
                    return velocity -= newVector;
                default: return Vector2.Zero;
            }
        }
    }
}
