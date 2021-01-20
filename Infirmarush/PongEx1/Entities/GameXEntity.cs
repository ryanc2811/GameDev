using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PongEx1.Game_Engine.Entities;
namespace PongEx1
{
    /// <summary>
    /// BASE CLASS FOR ALL IENTITIES IN THE GAME
    /// </summary>
     class GameXEntity : Entity
    {
        #region Variables
        //DECLARE A COLOR OF THE DEFAULT COLOR OF THE SPRITE
        protected Color spriteColour=Color.AntiqueWhite;
        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        protected Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE Vector2 used to change the velocity of entities, call it velocity
        protected Vector2 velocity;
        //DECLARE A FLOAT FOR THE ROTATION OF THE SPRITE
        protected float rotation;
        //DECLARE A VECTOR2 FOR THE DEFAULT SCALE OF THE SPRITE
        protected Vector2 scale=new Vector2(1f,1f);
        //DECLARE A VECTOR2 FOR THE ORIGIN POINT OF THE SPRITE
        protected Vector2 spriteOrigin;
        //DECLARE A FLOAT FOR THE LAYER DEPTH OF THE SPRITE
        protected float layerDepth = 0f;
        //PROPERTY FOR GETTING THE ID OF AN ENTITY
        public override string id { get; set; }
        #endregion
        
        #region Setters
        /// <summary>
        /// SETS THE CURRENT POSITION OF THE GAME ENTITY
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
        }

        /// <summary>
        /// SETTER FOR THE VELOCITY OF THE ENTITY
        /// </summary>
        /// <param name="pVelocity"></param>
        public void setVelocity(Vector2 pVelocity) { velocity = pVelocity; }

        /// <summary>
        /// SETTER FOR THE TEXTURE OF THE ENTITY
        /// </summary>
        /// <param name="pTexture"></param>
        public override void setTexture(Texture2D pTexture)
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
            pSpriteBatch.Draw(texture, entityLocn, null,spriteColour,rotation,spriteOrigin,scale,SpriteEffects.None,layerDepth);

        }
        #endregion

        #region GetPosition
        /// <summary>
        /// GETS THE POSITION OF THE ENTITY
        /// </summary>
        /// <returns></returns>
        public override Vector2 getPosition()
        {
            return entityLocn;
        }
        #endregion
        /// <summary>
        /// UPATES THE ENTITY BEHAVIOUR
        /// </summary>
        public override void Update()
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
    }
}
