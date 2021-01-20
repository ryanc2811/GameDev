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
using PongEx1.Entities.PatientStuff;
using PongEx1.Activity;
using PongEx1._Game.Events;
using PongEx1.Entities.Interacted;

namespace PongEx1.Entities
{
    /// <summary>
    /// CLASS FOR THE PLAYER ENTITY. CONTROLLED BY THE USER
    /// </summary>
    class Player : GameXEntity, ICollidable, IInputListener,IPlayer,IActivityListener,IDeathListener
    {
        #region DATA MEMBERS
        //DECLARE IList for STORING Input KEYS
        private IList<Keys> keyList;
        //DECLARE AN IINTERACTHANDLER FOR HANDLING THE INTERACT EVENT
        private IInteractHandler _InteractHandler;
        //DECLARE A FLOAT FOR STORING THE PLAYERS SPEED
        private float speed=10f;
        //DECLARE A FLOAT FOR STORING THE VALUE THAT REDUCES THE SPEED OF THE PLAYER WHEN MOVING DIAGONALLY
        private float reducedSpeed;
        //DECLARE A VECTOR2 FOR STORING THE POSITION BEFORE COLLISION
        private Vector2 tempPos;
        //DECLARE A BOOLEAN FOR STORING THE INTERACT STATE OF THE PLAYER
        private bool interact = false;
        //DECLARE A BOOLEAN TO CHECK IF THE PLAYER SHOULD STOP MOVING
        bool stopMoving = false;
        //DECLARE A BOOLEAN FOR STORING THE NUMBER THAT CORRESPONDS TO THE PATIENT THAT THE PLAYER IS INTERACTING WITH
        int currentPatientNum;
        //DECLARE A BOOLEAN FOR CHECKING IF THE INPUT HAS BEEN TAKEN
        bool gotInput = false;
        #endregion
        #region CONSTRUCTOR
        public Player()
        {
            //SET THE LAYER DEPTH TO BE THE LOWEST IN THE GAME
            layerDepth = 0.2f;
            //SET THE REDUCED SPEED TO BE 70% OF THE DEFAULT SPEED
            reducedSpeed = speed *= 0.7f;
        }
        #endregion
        #region PROPERTIES
        //PROPERTY FOR GETTING AND SETTING THE PLAYES CURRENT TOOL
        public ITool currentTool { get; set; }
        //PROPERTY FOR GETTING THE STATE OF THE INTERACT BOOLEAN
        public bool Interact { get { return interact; } }
        /// <summary>
        /// SETTER FOR THE INTERACT HANDLER
        /// </summary>
        /// <param name="interact"></param>
        public void AddInteractHandler(IInteractHandler interact)
        {
            _InteractHandler = interact;
        }
        /// <summary>
        /// GETS THE PLAYES HITBOX
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }
        #endregion
        #region COLLISION
        /// <summary>
        /// LISTENS FOR ENTITIES COLLIDING WITH THE PLAYER
        /// </summary>
        /// <param name="entity"></param>
        public void onCollide(IEntity entity)
        {
            //IF THE ENTITY SHOULD STOP THE PLAYER FROM MOVING, STOP THE PLAYER FROM MOVING
            if(entity is IImmovable)
                entityLocn = tempPos;
            //IF THE ENTITY IS A PATIENT
            if(entity is Patient)
            {
                //IF THE THE PATIENT HAS A TOOL
                if (currentTool != null)
                {
                    //IF THE INTERACT KEY IS PRESS AND THE TOOL IS A LEECH
                    if (interact && currentTool.GetName == "Leech")
                    {
                        //SEND DATA TO THE INTERACT HANDLER
                        _InteractHandler.OnInteract(true, ((Patient)entity).GetPatientNum);
                    }
                }
            }
        }
        #endregion
        #region UPDATE
        public override void Update()
        {
            //SET THE SPRITE ORIGIN OF THE PLAYER TO THE MIDDLE POINT OF THE TEXTURE
            spriteOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
          
            //IF THE PLAYER IS MOVING DIAGONALLY, MOVE AT A REDUCED SPEED
            if (velocity.X != 0 && velocity.Y != 0)
            {
                speed = reducedSpeed;
            }
            else
            {
                speed = 10;
            }
            //IF THE INTERACT KEY IS UP, RESET GOTINPUT BOOLEAN
            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                gotInput = false;
            }
            //IF THE PLAYER IS NOT INTERACTING
            if (!interact)
            {
                foreach(PatientNum num in Enum.GetValues(typeof(PatientNum)))
                {
                    //SEND DATA TO THE INTERACT HANDLER
                    _InteractHandler.OnInteract(false, num);
                }
            }
        }
        #endregion
        #region ACTIVATE TOOL
        /// <summary>
        /// ACTIVATE THE PLAYERS CURRENT TOOL
        /// </summary>
        /// <param name="patientNum"></param>
        public void ActivateTool(int patientNum)
        {
            //ACTIVATE THE CURRENT TOOL
            currentTool.SetActive(true,patientNum);
            //SET THE CURRENT PATIENT NUMBER TO THE PASSED VALUE
            currentPatientNum = patientNum;
            Console.WriteLine(currentTool.GetName + " Used");
            //IF THE PLAYER IS USING A BONESAW, STOP MOVING
            if (currentTool.GetName == "BoneSaw")
                stopMoving = true;
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR NEW INPUT
        /// USED TO MOVE THE PLAYER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //SET VELOCITY TO 0,0
            velocity = Vector2.Zero;
            //SET THE KEY LIST LOCALLY
            keyList = args.PressedKeys;
            //SET THE TEMP POS TO THE CURRENT POSITION
            tempPos = entityLocn;
            //RESET INTERACT BOOLEAN
            interact = false;
            //IF THE PLAYER SHOULD STOP MOVING
            if (!stopMoving) {
                //MOVE THE PLAYER FORWARD
                if (keyList.Contains(Keys.W))
                {
                rotation = MathHelper.ToRadians(0f);
                velocity.Y -= speed;
                //update the PLAYERS POSITION
                entityLocn.Y += velocity.Y;
                }
                //MOVE THE PLAYER BACKWARDS
                else if (keyList.Contains(Keys.S))
                {
                    rotation = MathHelper.ToRadians(180f);
                    velocity.Y += speed;
                    //update the PLAYER position
                    entityLocn.Y += velocity.Y;
                }
                //MOVE THE PLAYER LEFT
                if (keyList.Contains(Keys.A))
                {
                    rotation = MathHelper.ToRadians(270f);
                    velocity.X -= speed;
                    //update the PLAYER position
                    entityLocn.X += velocity.X;
                }
                //MOVE THE PLAYER RIGHT
                else if (keyList.Contains(Keys.D))
                {
                    rotation = MathHelper.ToRadians(90f);
                    velocity.X += speed;
                    //update the paddles position
                    entityLocn.X += velocity.X;
                }
                //IF THE INTERACT KEY IS DOWN, SET THE INTERACT STATE TO TRUE
                if (keyList.Contains(Keys.F) && !gotInput)
                {
                    interact = true;
                    gotInput = true;
                }
            }
        }
        
        
        /// <summary>
        /// LISTENS FOR A PATIENTS DEATH
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDeath(object sender, IEvent args)
        {
            if (((DeathEvent)args).Dead[(PatientNum)currentPatientNum])
                stopMoving = false;
        }
        /// <summary>
        /// LISTENS FOR THE ACTIVITY TO END
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnActivityEnd(object sender, IEvent args)
        {
            if (((ActivityEvent)args).Ended[(PatientNum)currentPatientNum])
                stopMoving = false;
        }
        #endregion
    }
}
