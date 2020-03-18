using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongEx1.Entities
{
    
    abstract class PongEntity : Entity
    {
        #region Variables
        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        public Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE double used to make the ball movement more realistic, by giving it spin, call it Spin
        public float Spin = 5.5f;
        //DECLARE Vector2 used to change the velocity of entities, call it velocity
        public Vector2 velocity;
        //DECLARE Id
        public override string id { get; set; }
        #endregion

        #region Constructor
        public PongEntity()
        {
            //do nothing
        }
        #endregion

        #region Setters
        // Set the position of the pong entity
        public override void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
        }

        //DECLARE Vector2 for dealing with speed and direction of ball, name it velocity
        public void setVelocity(Vector2 pVelocity){ velocity = pVelocity; }

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
            pSpriteBatch.Draw(texture, entityLocn, Color.AntiqueWhite);
            
        }
        #endregion

        #region GetPosition
        //Return vector 2 Location
        public override Vector2 getPosition()
        {
            return entityLocn;
        }
        #endregion

        #region Update
        public override void Update()
        {
            //do Nothing
        }
        #endregion
    }




}
