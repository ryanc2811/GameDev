﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine.Animation_Stuff;
using GameEngine.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace GameEngine.Entities
{
    /// <summary>
    /// BASE CLASS FOR ALL IENTITIES IN THE GAME
    /// </summary>
     class GameXEntity : Entity
    {
        #region Variables
        //DECLARE A COLOR OF THE DEFAULT COLOR OF THE SPRITE
        protected Color spriteColour=Color.AntiqueWhite;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE A FLOAT FOR THE ROTATION OF THE SPRITE
        protected float rotation;
        //DECLARE A VECTOR2 FOR THE DEFAULT SCALE OF THE SPRITE
        protected Vector2 scale=new Vector2(1f,1f);
        //DECLARE A VECTOR2 FOR THE ORIGIN POINT OF THE SPRITE
        protected Vector2 spriteOrigin=Vector2.Zero;
        //DECLARE A FLOAT FOR THE LAYER DEPTH OF THE SPRITE
        protected float layerDepth = 0f;
        protected SpriteEffects spriteEffect;
        protected IAnimationManager animationManager;

        protected Transform transform;
        #endregion
        
        public GameXEntity()
        {
            transform = new Transform();
        }
        #region Setters
        /// <summary>
        /// Property for CURRENT Transform OF THE GAME ENTITY
        /// </summary>
        public override Transform Transform { get { return transform; } }
        ///PROPERTY FOR GETTING THE ID OF AN ENTITY
        public override string id { get; set; }
        /// <summary>
        /// SETTER FOR THE TEXTURE OF THE ENTITY
        /// </summary>
        /// <param name="pTexture"></param>
        public override void SetTexture(Texture2D pTexture)
        {
            texture = pTexture;
        }
        #endregion

        #region Draw
        /// <summary>
        /// DRAWS THE TEXTURE OF THE ENTITY USING THE SPRITE BATCH
        /// </summary>
        /// <param name="pSpriteBatch"></param>
        public override void draw(SpriteBatch pSpriteBatch)
        {
            //draw the entity using the spritebatch
            if (texture != null)
                pSpriteBatch.Draw(texture, Transform.position, null, spriteColour, rotation, spriteOrigin, scale, spriteEffect, layerDepth);
            else if (animationManager != null)
                animationManager.Draw(pSpriteBatch,Transform.position);

        }
        #endregion

        #region Getters
        /// <summary>
        /// GETS THE POSITION OF THE ENTITY
        /// </summary>
        /// <returns></returns>
        public override Vector2 GetPosition()
        {
            return Transform.position;
        }

        public override Texture2D GetTexture()
        {
            return texture;
        }
        public int Height()
        {
            //return height of the texture, witch is height of the paddle
            return texture.Height;
        }
        public int Width()
        {
            //return width of the texture, witch is width of the paddle
            return texture.Width;
        }
        #endregion

        /// <summary>
        /// UPATES THE ENTITY BEHAVIOUR
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            //DO NOTHING
        }
        /// <summary>
        /// INITIALISES THE ENTITY
        /// </summary>
        public override void Initialise()
        {
            //DO NOTHING
        }

        public override void SetPosition(float x, float y)
        {
            transform.position = new Vector2(x, y);
        }

        public override void SetVelocity(float x, float y)
        {
            transform.velocity = new Vector2(x, y);
        }
    }
}
