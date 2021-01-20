using PongEx1._Game.Events;
using PongEx1.Activity;
using PongEx1.Entities.Damage;
using PongEx1.Entities.PatientStuff;
using PongEx1.Tools.Tool_Behaviour;
using PongEx1._Game.Behaviour;
using PongEx1.Entities.Healing;
using System;
using PongEx1._Game.GameEnd;

namespace PongEx1.Tools.Tool_Behaviour
{
    /// <summary>
    /// ABSTRACT CLASS FOR ALL TOOL BEHAVIOURS
    /// </summary>
    public abstract class ToolBehaviour : IBehaviour,IDeathListener,IToolBehaviour,IGameEndListener
    {
        #region DATA MEMBERS
        //DECLARE A BOOLEAN FOR CHECKING IF THE TOOL BEHAVIOUR IS ACTIVE
        protected bool isActive = false;
        //DECLARE AN INT FOR STORING THE PATIENT NUMBER ASSOCIATE WITH THIS BEHAVIOUR
        protected int patientNum;
        //DECLARE A BOOLEAN FOR CHECK IF THE BEHAVIOUR HAS ENDED
        protected bool hasEnded = false;
        //DECLARE A BOOLEAN FOR FLAGGING WHEN THE FIRST FRAME OF THE BEHAVIOUR HAS HAPPENED
        protected bool initial = false;
        //DECLARE A BOOLEAN FOR CHECKING IF THE PATIENT IS DEAD
        protected bool isDead = false;
        //DECLARE A REFERENCE TO THE IDAMAGEHANDLER
        protected IDamageHandler _damageHandler;
        //DECLARE A REFERENCE TO THE IACTIVITYHANDLER
        protected IActivityHandler _activityHandler;
        //DECLARE A REFERENCE TO THE IHEALHANDLER
        protected IHealHandler _healHandler;
        #endregion
        #region PROPERTIES
        //PROPERTY FOR GETTING THE HAS ENDED BOOLEAN
        public bool HasEnded
        {
            get { return hasEnded; }
        }
        /// <summary>
        /// SETTER FOR THE DAMAGE HANDLER
        /// </summary>
        /// <param name="pDamageHandler"></param>
        public void AddDamageHandler(IDamageHandler pDamageHandler)
        {
            _damageHandler = pDamageHandler;
        }
        /// <summary>
        /// SETTER FOR THE ACTIVITY HANDLER
        /// </summary>
        /// <param name="pActivityHandler"></param>
        public void AddActivityHandler(IActivityHandler pActivityHandler)
        {
            _activityHandler = pActivityHandler;
        }
        /// <summary>
        /// SETTER FOR THE HEAL HANDLER
        /// </summary>
        /// <param name="pHealHandler"></param>
        public void AddHealHandler(IHealHandler pHealHandler)
        {
            _healHandler = pHealHandler;
        }
        /// <summary>
        /// SETTER FOR THE PATIENT NUMBER
        /// </summary>
        /// <param name="patientNum"></param>
        public void SetPatientNum(int patientNum)
        {
            this.patientNum = patientNum;
        }
        #endregion
        #region BEHAVIOUR
        /// <summary>
        /// EXECUTES THE BEHAVIOUR OF THE TOOL
        /// </summary>
        public abstract void Behaviour();
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR THE DEATH EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnDeath(object sender, IEvent args)
        {
            
            isDead = ((DeathEvent)args).Dead[(PatientNum)patientNum];
            //IF THE PATIENT IS DEAD
            if (((DeathEvent)args).Dead[(PatientNum)patientNum])
            {
                //ACTIVITY HAS ENDED
                hasEnded = true;
                initial = false;
            }
        }
        /// <summary>
        /// LISTENS FOR THE ON GAME END EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnGameEnd(object sender, IEvent args)
        {
            //ACTIVITY HAS ENDED
            hasEnded = true;
            initial = false;
        }
        #endregion
    }
}
