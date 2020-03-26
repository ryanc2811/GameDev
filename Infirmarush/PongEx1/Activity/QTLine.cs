using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.Entities;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    class QTLine : GameXEntity, IShape, ICollidable
    {
        private Vector2 startPos;
        private float offset = 200f;
        private bool moveLeft = false;
        private float speed = 0.1f;
        private bool hasHitGreen = false;
        public bool gethasHitGreen{get{ return hasHitGreen; } }
        private bool hasHitContainer = false;
        ContentManager content;


        public QTLine()
        {
            startPos.X = entityLocn.X + offset;
           
        }

        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public int getWidth()
        {
            return texture.Width;
        }
        public int getHeight()
        {
            return texture.Height;
        }
        public void onCollide(IEntity entity)
        {
            if (entity is QTGreen&&!hasHitContainer)
            {
                hasHitGreen = true;
                hasHitContainer = false;
            }
            if(entity is Container&&!hasHitGreen)
            {
                hasHitGreen = false;
                hasHitContainer = true;
            }
            //Console.WriteLine(hasHitGreen);
        }

        public void setContent(ContentManager contentManager)
        {
            content = contentManager;
        }
        
        public void setTexture(string texture)
        {

            base.setTexture(content.Load<Texture2D>(texture));
        }
        public override void Update()
        {

            if (!moveLeft)
            {
                velocity.X += speed;
                entityLocn.X += velocity.X;
                if (entityLocn.X > startPos.X)
                {
                    moveLeft = true;
                    
                }
            }
            else if (moveLeft)
            {
                velocity.X -= speed;
                entityLocn.X += velocity.X;
                if (entityLocn.X < startPos.X)
                    moveLeft = false;
            }
            
        }
    }
}
