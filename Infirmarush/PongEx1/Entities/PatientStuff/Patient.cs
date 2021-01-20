using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities._Symbols;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Healing;
using PongEx1.Entities.PatientStuff.Health_Bar;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Illness;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// CLASS FOR THE PATIENT ENTITY
    /// </summary>
    class Patient : GameXEntity,ICollidable,IDamageListener,IImmovable,IActivityListener,ITimerListener,IHealListener
    {
        #region DATA MEMBERS
        //DECLARE A PATIENTNUM FOR STORING THE PATIENT NUMBER THAT CORRESPONDS TO THIS PATIENT
        PatientNum patientNum;
        //DECLARE A IDEATHHANDLER FOR HANDLING THE DEATH OF THIS PATIENT
        IDeathHandler death;
        //DECLARE an IIllnessFactory for creating new illnesses, call it illnessFactory
        IIllnessFactory illnessFactory;
        //DECLARE a reference for IIllness
        IIllness illness;
        //DECLARE an IList for storing the symptoms from illness locally, call it symptoms
        IList<Symptom> symptoms;
        //DECLARE a reference to BodyPart
        BodyPart bodyPart;
        //DECLARE A REFERENCE TO THE HEALTH BAR THAT BELONGS TO THIS PATIENT
        IHealthBar healthBar;
        //DECLARE A REFERENC TO THE SYMBOL MANAGER
        ISymbolManager symbolManager;
        //DECLARE A DOUBLE FOR STORING THE CURRENT HEALTH OF THE PATIENT
        double health;
        //DECLARE A DOUBLE FOR STORING THE MAX HEALTH OF THE PATIENT
        double maxHealth = 1.0;
        //DECLARE A BOOLEAN FOR CHECKING IF THE PATIENT IS DEAD
        bool isDead = false;
        //DECLARE A BOOLEAN FOR CHECKING IF AN ACTIVITY HAS ENDED
        bool activityEnded = false;
        //DECLARE A VECTOR2 FOR STORING THE START POSITION OF THE PATIENT
        Vector2 startPosition;
        //DECLARE BOOL FOR COLLIDING
        bool hasCollided = false;
        //DECLARE A BOOLEAN FOR CHECKING WHEN THE GAME HAS FIRST BEEN EXECUTED
        bool initial = false;
        #endregion
        public Patient()
        {
            //INSTANTIATE a new illness factory
            illnessFactory = new IllnessFactory();
            //Generate a new illness for the patient
            CreateNewIllness();
            //set health to max health
            health = maxHealth;
            
        }
        #region SET VARIABLES
        /// <summary>
        /// ADDS THE DEATH HANDLER TO THE PATIENT
        /// </summary>
        /// <param name="deathHandler"></param>
        public void AddDeathHandler(IDeathHandler deathHandler)
        {
            death = deathHandler;
        }
        /// <summary>
        /// ADDS A SYMBOL MANAGER TO THE PATIENT
        /// SYMBOL MANAGER ADDS THE CURRENT ILLNESS PATIENT HAS TO THE SYMBOL MANAGER
        /// </summary>
        /// <param name="pSymbolManager"></param>
        public void AddSymbolManager(ISymbolManager pSymbolManager)
        {
            symbolManager = pSymbolManager;
        }
        /// <summary>
        /// GETS THE PATIENT NUMBER OF THE PATIENT
        /// </summary>
        public PatientNum GetPatientNum
        {
            get { return patientNum; }
        }
        /// <summary>
        /// SET THE HEALTH BAR OF THE PATIENT
        /// </summary>
        /// <param name="healthBar"></param>
        public void SetHealthBar(IHealthBar healthBar)
        {
            this.healthBar = healthBar;
        }
        /// <summary>
        /// SETS THE PATIENT NUMBER OF THE PATIENT
        /// </summary>
        /// <param name="patientNum"></param>
        public void SetPatientNum(PatientNum patientNum)
        {
            this.patientNum = patientNum;
            
        }
        #endregion
        #region HITBOX
        /// <summary>
        /// GETS THE HITBOX THE PATIENT
        /// </summary>
        /// <returns></returns>
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }
        #endregion
        #region GENERATE AN ILLNESS
        /// <summary>
        /// GENERATE A NEW ILLNESS FOR THE PATIENT
        /// </summary>
        private void CreateNewIllness()
        {
            //create a new illness using the factory
            illness = illnessFactory.create();
            //add the symptoms content to the local symptoms list
            symptoms = illness.getSymptoms;
            //add the the body part from illness and set local body part to it
            bodyPart = illness.getBodyPart;
            Console.WriteLine(bodyPart);
        }
        #endregion
        #region COLLISION
        /// <summary>
        /// LISTENS FOR A COLLISION WITH THIS ENTITY
        /// </summary>
        /// <param name="entity"></param>
        public void onCollide(IEntity entity)
        {
            //IF THE COLLIDED ENTITY IS A PLAYER
            if (entity is IPlayer) {
                //IF THE PATIENT HAS NOT COLLIDED BEFORE AND THE PLAYER HAS INTERACTED
                if (!hasCollided && ((IPlayer)entity).Interact)
                {
                    //SET COLLISION TO TRUE
                    hasCollided = true;
                    Console.WriteLine(bodyPart);
                    //ITERATE THROUGH THE SYMPTOMS OF THE ILLNESS
                    for (int i = 0; i < symptoms.Count; i++)
                    {
                        Console.WriteLine(symptoms[i]);
                        //IF THE PLAYERS CURRENT TOOL IS NOT NULL
                        if (((IPlayer)entity).currentTool != null)
                        {
                            //IF THE SYMPTOMS CONTAIN AN INFECTION AND THE PLAYERS CURRENT TOOL IS A BONESAW
                            if (symptoms[i] == Symptom.infection && ((IPlayer)entity).currentTool.GetName == "BoneSaw")
                            {
                                //ACTIVATE THE PLAYERS TOOL
                                ((IPlayer)entity).ActivateTool((int)patientNum);
                            }
                            //IF THE SYMPTOM IS NAUSEA AND THE TOOL IS LEECH
                            else if (symptoms[i] == Symptom.nausea && ((IPlayer)entity).currentTool.GetName == "Leech")
                            {
                                //ACTIVATE THE PLAYERS TOOL
                                ((IPlayer)entity).ActivateTool((int)patientNum);
                            }
                            else
                            {
                                Console.WriteLine("Wrong Tool, Sorry");
                            }
                        }
                }
            }
        }
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR THE DAMAGE EVENT
        /// TAKES HEALTH AWAY FROM THE PATIENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDamageTaken(object sender, IEvent args)
        {
            //IF THE HEALTH IS GREAT THAN 0
            if (health > 0)
            {
                //TAKE HEALTH AWAY FROM THE PATIENT
                health -= ((ReceiveDamageEvent)args).Damage[patientNum];
                //IF THE PATIENT HAS TO SYMPTOMS TAKE DOUBLE DAMAGE
                if(symptoms.Count>1)
                    health -= ((ReceiveDamageEvent)args).Damage[patientNum];
                //UPDATE THE HEALTH BAR WITH THE NEW HEALTH VALUE
                healthBar.UpdateHealth(health);
            }
        }
        /// <summary>
        /// LISTENS FOR THE ACTIVITY TO END
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnActivityEnd(object sender, IEvent args)
        {
            //IF THE ACTIVITY HAS ENDED
            if (((ActivityEvent)args).Ended[patientNum])
            {
                hasCollided = false;
                //PATIENT IS CURED
                activityEnded = true;
                //SET POSITION OFF SCREEN
                setPosition(1111, 1111);
                //SET THE HEALTH BAR POSITION OFF SCREEN
                ((IEntity)healthBar).setPosition(1111, 1111);
            }

        }
        /// <summary>
        /// LISTENS FOR THE TO END
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimerStart(object sender, IEvent args)
        {
            //RESPAWN IF THE TIMER HAS ENDED
            if (((TimerEvent)args).DictTimerEnd[patientNum])
                Respawn();
        }
        /// <summary>
        /// LISTENS FOR THE PATIENT TO BE HEALED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnHeal(object sender, IEvent args)
        {
            //IF THE HEALTH IS LESS THAN MAX HEALTH
            if (health < maxHealth)
            {
                //HEAL THE PATIENT
                health += ((ReceiveHealEvent)args).Heal[patientNum];
                if (symptoms.Count > 1)
                    health += ((ReceiveHealEvent)args).Heal[patientNum];
                //UPDATE THE HEALTH BAR
                healthBar.UpdateHealth(health);
            }
        }
        #endregion
        #region RESPAWN
        /// <summary>
        /// RESPAWN THE PATIENT
        /// </summary>
        private void Respawn()
        {
            //IF THE PATIENT IS DEAD
            if (isDead)
            {
                isDead = false;
                //CREATE A NEW ILLNESS
                CreateNewIllness();
                //ADD THE ILLNESS TO THE SYMBOL MANAGER
                symbolManager.AddIllness(illness, patientNum);
                //SEND DATA TO THE DEATH HANDLER
                death.OnDeath(false, patientNum);
                //RESET HEALTH
                health = maxHealth;
                //RESET POSITION
                entityLocn = startPosition;
                //RESET HEALTH BAR
                healthBar.UpdateHealth(health);
                //RESET HEALTH BAR POSITION
                ((IEntity)healthBar).setPosition(healthBar.StartPos.X,healthBar.StartPos.Y);
            }
            //IF THE PATIENT IS CURED
            if (activityEnded)
            {
                activityEnded = false;
                //GENERATE A NEW ILLNESS
                CreateNewIllness();
                //ADD THE ILLNESS TO THE SYMBOL MANAGER
                symbolManager.AddIllness(illness, patientNum);
                //RESET HEALTH
                health = maxHealth;
                //RESET POSITION
                entityLocn = startPosition;
                //RESET HEALTH BAR
                healthBar.UpdateHealth(health);
                //RESET HEALTH BAR POSTION
                ((IEntity)healthBar).setPosition(healthBar.StartPos.X, healthBar.StartPos.Y);
            }
        }
        #endregion
        #region UPDATE
        public override void Update()
        {
            //ON THE FIRST FRAME OF UPDATE
            if (!initial)
            {
                initial = true;
                //SET THE START POSTION TO THE CURRENT POSTION
                startPosition = entityLocn;
                //UPDATE THE HEALTH BAR
                healthBar.UpdateHealth(health);
                //ADD THE ILLNESS TO THE SYMBOL MANAGER
                symbolManager.AddIllness(illness, patientNum);
            }
           //IF PATIENT IS DEAD   
           if (health <= 0&&!isDead)
            {
                isDead = true;
                //RESET COLLISION
                hasCollided = false;
                //SEND DATA TO THE DEATH HANDLER
                death.OnDeath(true,patientNum);
                Console.WriteLine(patientNum+" is Dead");
                //SET THE POSITION OFF SCREEN
                setPosition(1111, 1111);
                //SET THE HEALTH BAR OFFSCREEN
                ((IEntity)healthBar).setPosition(1111, 1111);
            }
            //IF THE INTERACT KEY IS UP
            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                //RESET COLLISION
                hasCollided = false;
            }
        }
        #endregion
    }
}
