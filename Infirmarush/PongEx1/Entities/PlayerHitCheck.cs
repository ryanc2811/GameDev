using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Input;
namespace PongEx1.Entities
{
    class PlayerHitCheck : HitCheck, IInputListener
    {
        private float speed = 10f;
        private float reducedSpeed;
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        
        public bool getHitWall { get { return boolHitWall; } }
        public void setSpriteOrigin(Vector2 spriteOrigin)
        {
            //spriteOrigin.Y += 10;
            this.spriteOrigin = spriteOrigin;
        }
        public PlayerHitCheck()
        {
            reducedSpeed = speed *= 0.7f;
            
        }
        //public override void Update()
        //{
        //    boolHitWall = false;
        //    if (velocity.X != 0 && velocity.Y != 0)
        //    {
        //        speed = reducedSpeed;
        //    }
        //    else
        //    {
        //        speed = 10;
        //    }
        //}
        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            velocity = Vector2.Zero;
            keyList = args.PressedKeys;
            tempPos = entityLocn;
            if (keyList.Contains(Keys.W))
            {
                rotation = MathHelper.ToRadians(0f);
                velocity.Y -= speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
            }
            else if (keyList.Contains(Keys.S))
            {
                rotation =MathHelper.ToRadians(180f);
                velocity.Y += speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
            }
            if (keyList.Contains(Keys.A))
            {
                rotation = MathHelper.ToRadians(270f);
                velocity.X -= speed;
                //update the paddles position
                entityLocn.X += velocity.X;
            }

            else if (keyList.Contains(Keys.D))
            {
                rotation = MathHelper.ToRadians(90f);
                velocity.X += speed;
                //update the paddles position
                entityLocn.X += velocity.X;
            }
        }
    }
    }

