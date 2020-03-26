using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using PongEx1.Tools;

namespace PongEx1.Entities
{
    class Player : GameXEntity, ICollidable, IInputListener
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        private float speed=10f;
        private float reducedSpeed;
        private Vector2 tempPos;
        private bool interact = false;
        private bool itemAdded = false;
       
        //private IEntity HitCheck;
       
        public Player()
        {
            reducedSpeed = speed *= 0.7f;
        }
        public ITool currentTool { get; private set; }

        //public void settHitCheck(IEntity HitCheck)
        //{
        //     this.HitCheck = HitCheck;
        //}
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            entityLocn = tempPos;
            if(entity is IToolBench)
            {
                if (interact&&!itemAdded)
                {
                    itemAdded = true;
                    currentTool =((IToolBench)entity).getTool("BoneSaw");
                    Console.WriteLine(currentTool.GetName + " Added");
                }
            }
        }
        public override void Update()
        {
            spriteOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
            if (currentTool != null)
                currentTool.Update();
            
            if (velocity.X != 0 && velocity.Y != 0)
            {
                speed = reducedSpeed;
            }
            else
            {
                speed = 10;
            }
            
        }
        public void ActivateTool()
        {
            currentTool.setActive(true);
        }
        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            velocity = Vector2.Zero;
            keyList = args.PressedKeys;
            tempPos = entityLocn;
            interact = false;
        
            if (keyList.Contains(Keys.W))
            {
                rotation = MathHelper.ToRadians(0f);
                velocity.Y -= speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
            }
            else if (keyList.Contains(Keys.S))
            {
                rotation = MathHelper.ToRadians(180f);
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
            if (keyList.Contains(Keys.F))
            {
                interact = true;
            }

        }
    }
}
