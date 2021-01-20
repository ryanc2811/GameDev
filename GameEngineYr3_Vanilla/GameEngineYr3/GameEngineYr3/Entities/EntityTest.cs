using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameEngine.Collision;
using GameEngine.Input;
namespace GameEngine.Entities
{
    class EntityTest : GameXEntity, IInputListener, ICollidable
    {

        private Vector2 tempPos;
        public override void Initialise()
        {
            if (texture != null)
            {
                spriteOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
                scale = new Vector2(0.125f, 0.125f);
            }
                
            tempPos = position;
            speed = 3;
            velocity.X= 2 * speed;
            velocity.Y = 2 * speed;
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            position = tempPos;
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            tempPos = position;
                if (args.PressedKeys.Contains(Microsoft.Xna.Framework.Input.Keys.D))
                    position.X++;
                if (args.PressedKeys.Contains(Microsoft.Xna.Framework.Input.Keys.A))
                    position.X--;
        }
        public override void Update()
        {
            float y = position.Y;
            float x = position.X;
            float vX = velocity.X;
            //tempPos= position;
            //FACE IN MOVE DIRECTION
            if (vX > 0)
            {
                rotation = 90;
                spriteEffect = SpriteEffects.None;
            }
            else
            {
                rotation = -90;
                spriteEffect = SpriteEffects.FlipHorizontally;
            }

            if (y <= 0)
            {
                velocity.Y=2 * speed;
            }
            else if (y >= (Kernel.SCREENHEIGHT+120 - texture.Height))
            {
                velocity.Y = -2 * speed;

            }
            if (x <= 0)
            {
                velocity.X=2 * speed;
            }
            else if (x >= (Kernel.SCREENWIDTH+120 - texture.Width))
            {

                velocity.X=-2 * speed;

            }
            position += velocity;
        }
    }
}
