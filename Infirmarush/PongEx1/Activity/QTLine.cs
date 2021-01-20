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
    /// <summary>
    /// Quick time object that moves side to side when the activity is active
    /// </summary>
    class QTLine : GameXEntity, IQTLine, ICollidable,IQuickTimeObj
    {
        //DECLARE a Vector2 for storing the start position of the quick time object
        private Vector2 startPos;
        //DECLARE a float for offsetting the line position
        private float offset = 190f;
        //DECLARE a bool for checking if the entity is moving left or right
        private bool moveLeft = false;
        //DECLARE a float for storing the speed of the quick time object
        private float speed = 3.5f;
        //DECLARE a boolean for checking if the QTLine has collided with the QTGreen object
        private bool hasHitGreen = false;
        //DECLARE a bool for checking if the activity is active
        private bool isActive = false;
        //property for getting the hasHitGreen boolean
        public bool gethasHitGreen{get{ return hasHitGreen; } }
        //DECLARE a reference to the QTGreen object
        private IEntity QTGreen;
        /// <summary>
        /// Gets the Hitbox of the entity
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }
        /// <summary>
        /// Triggered when the entity collides with another ICollidable entity
        /// </summary>
        /// <param name="entity"></param>
        public void onCollide(IEntity entity)
        {
            //if the entity collides with a QTGreen object
            if (entity is QTGreen)
            {
                //trigger the hasHitGreen boolean
                hasHitGreen = true;
                //store a reference to the QTGreen object
                QTGreen = entity;
            }
        }
        /// <summary>
        /// Change the colour of the QTLine when the line has collided with the QTGreen object
        /// </summary>
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
            //if the activity is active
            if (isActive)
            {
                //move along the x axis
                entityLocn.X += velocity.X;
                //Change the colour of the QTLine
                SwitchColour();
                if (QTGreen != null)
                {
                    //if the QTLine position is outside the QTGreen area then set the hasHitGreen boolean to false
                    if (entityLocn.X >= QTGreen.getPosition().X + ((IShape)QTGreen).getWidth() || entityLocn.X <= QTGreen.getPosition().X)
                    {
                        hasHitGreen = false;
                    }
                }
                //if the QTLine is moving right
                if (!moveLeft)
                {
                    //move right
                    velocity.X = speed;
                    //if the entity has moved outside the QTContainer, start moving left
                    if (entityLocn.X > startPos.X + offset)
                    {
                        moveLeft = true;
                    }
                }
                else
                {
                    //move left
                    velocity.X = -speed;
                    //if the entity has moved outside the QTContainer, start moving left
                    if (entityLocn.X < startPos.X)
                    {
                        moveLeft = false;
                    }
                        
                }
            }
        }
        /// <summary>
        /// sets the start position of the quick time object for when the activity is active
        /// </summary>
        /// <param name="position"></param>
        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }
        /// <summary>
        /// sets the quick time entity active
        /// </summary>
        /// <param name="active"></param>
        public void SetActive(bool active)
        {
            isActive = active;
            //if the entity is active move the position onto the screen
            if (isActive)
                setPosition(startPos.X, startPos.Y);
            //move the position off screen
            else
                setPosition(1111, 2222);
        }
    }
}
