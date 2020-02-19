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
        public static double acc1 = 0.04;
        public static double acc2 = 0.04;
        private static double maxSpeed=10;

        //gets the keyboard input
        public static Vector2 GetKeyboardInputDirection(PlayerIndex pPlayerIndex)
        {
            
            direction.Y = 0;
            KeyboardState keyboardState = Keyboard.GetState(pPlayerIndex);
            //if player one interacts with the keyboard
            if (pPlayerIndex==PlayerIndex.One )
            {
                //if the w key is pressed
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc1 >= maxSpeed)
                    {
                        acc1 = maxSpeed;
                    }
                    acc1++;
                    //move paddle upwards
                    direction.Y-=(int)acc1;
                   
                }
                //if the s key is pressed
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc1 >= maxSpeed)
                    {
                        acc1 = maxSpeed;
                    }
                    acc1++;
                    //move paddle downwards
                    direction.Y +=(int)acc1;
                   
                }
                //else if (keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.S)||acc1>=maxSpeed)
                //{
                //    acc1 = 0.04;
                //}


            }
            //if player one interacts with the keyboard
            if (pPlayerIndex == PlayerIndex.Two)
            {
                //if the Up key is pressed
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc2 >= maxSpeed)
                    {
                        acc2 = maxSpeed;
                    }
                    acc2++;
                    //move paddle upwards
                    direction.Y-=(int)acc2;
                   
                }
                //if the Down key is pressed
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc2 >= maxSpeed)
                    {
                        acc2 = maxSpeed;
                    }
                    acc2++;
                    //move paddle downwards
                    direction.Y += (int)acc2;
                    
                }
                //else if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down)||acc2>=maxSpeed)
                //{
                //    acc2 = 0.04;

                //}
                
            }
            
            return direction;
        }

        public void Update()
        {

        }
    }
}
