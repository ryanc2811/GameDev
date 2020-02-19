using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;

namespace PongEx1
{
    class Input
    {
        //DECLARE STATIC VECTOR2 for storing the direction the paddle is moving, name is direction
        private static Vector2 direction;
        

        public static Vector2 GetKeyboardInputDirection(PlayerIndex pPlayerIndex)
        {
            direction.Y = 0;
            Console.WriteLine(direction);
            KeyboardState keyboardState = Keyboard.GetState(pPlayerIndex);

            if (pPlayerIndex==PlayerIndex.One)
            {

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    direction.Y = -1;

                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {

                    direction.Y = 1;

                }

            }
            
            if (pPlayerIndex == PlayerIndex.Two)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    direction.Y = -1;

                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    direction.Y = 1;

                }

            }

            return direction;
        }
    }
}
