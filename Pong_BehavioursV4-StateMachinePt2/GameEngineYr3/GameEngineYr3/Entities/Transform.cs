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
        //DECLARE a vector2 for storing the position of the transform
        public Vector2 position;
        //DECLARE A vector2 for storing the velocity of the transform
        public Vector2 velocity;
        /// <summary>
        /// Initialses member variables
        /// </summary>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        public Transform(Vector2 position, Vector2 velocity)
        {
            this.position = position;
            this.velocity = velocity;
        }
        /// <summary>
        /// Adds the current position to the passed vector
        /// </summary>
        /// <param name="pOperator"></param>
        /// <param name="newVector"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Adds the current velocity to the passed vector
        /// </summary>
        /// <param name="pOperator"></param>
        /// <param name="newVector"></param>
        /// <returns></returns>
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
