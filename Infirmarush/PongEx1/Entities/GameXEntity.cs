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
     class GameXEntity : Entity
    {
        #region Variables
        protected Color spriteColour=Color.AntiqueWhite;
        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        protected Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE Vector2 used to change the velocity of entities, call it velocity
        protected Vector2 velocity;
        protected float rotation;
        protected Vector2 scale=new Vector2(1f,1f);
        protected Vector2 spriteOrigin;
        //DECLARE Id
        public override string id { get; set; }
        #endregion
       

        #region Setters
        // Set the position of the pong entity
        public override void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
        }

        //DECLARE Vector2 for dealing with speed and direction of ball, name it velocity
        public void setVelocity(Vector2 pVelocity) { velocity = pVelocity; }

        // store the texture of the pong entity in texture variable
        public override void setTexture(Texture2D pTexture)
        {
            texture = pTexture;
        }
        #endregion

        #region Draw
        //draw the entity into the game
        public override void draw(SpriteBatch pSpriteBatch)
        {
            //draw the entity using the spritebatch
            pSpriteBatch.Draw(texture, entityLocn, null,spriteColour,rotation,spriteOrigin,scale,SpriteEffects.None,0);

        }
        #endregion

        #region GetPosition
        //Return vector 2 Location
        public override Vector2 getPosition()
        {
            return entityLocn;
        }
        #endregion

        public override void Update()
        {
            
        }

        public override void Initialise()
        {
            
        }
    }
}
