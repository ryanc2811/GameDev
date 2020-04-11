using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PongEx1._Game.Events;
using PongEx1.Entities;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    class QTLine : GameXEntity, IQTLine, ICollidable,IQuickTimeObj
    {
        private Vector2 startPos;
        private float offset = 190f;
        private bool moveLeft = false;
        private float speed = 3.5f;
        private bool hasHitGreen = false;
        private bool isActive = false;
        //private bool initial = false;
        public bool gethasHitGreen{get{ return hasHitGreen; } }
        IEntity QTGreen;
        
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }
        public void onCollide(IEntity entity)
        {
            if (entity is QTGreen)
            {
                hasHitGreen = true;
                QTGreen = entity;
            }
        }
        
        private void SwitchColour()
        {
            //if not it green, set texture to red
            if (!hasHitGreen)
                spriteColour = Color.AntiqueWhite;
            //if the line is in the green area, set texture to black
            else
            {
                spriteColour = Color.Black;
            }
        }
        public override void Update()
        {
            if (isActive)
            {
                entityLocn.X += velocity.X;
                SwitchColour();
                if (QTGreen != null)
                {
                    if (entityLocn.X >= QTGreen.getPosition().X + ((IShape)QTGreen).getWidth() || entityLocn.X <= QTGreen.getPosition().X)
                    {
                        hasHitGreen = false;
                    }
                }
                if (!moveLeft)
                {
                    velocity.X = speed;
                    if (entityLocn.X > startPos.X + offset)
                    {
                        moveLeft = true;
                    }
                }
                else
                {
                    velocity.X = -speed;
                    if (entityLocn.X < startPos.X)
                    {
                        moveLeft = false;
                    }
                        
                }
            }
        }
        
        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }

        public void SetActive(bool active)
        {
            isActive = active;
            
            if (isActive)
                setPosition(startPos.X, startPos.Y);
            else
                setPosition(1111, 2222);
        }
    }
}
