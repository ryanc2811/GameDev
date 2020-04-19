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
    public abstract class ToolBehaviour : IBehaviour,IDeathListener,IToolBehaviour,IGameEndListener
    {
        protected bool isActive = false;
        protected int patientNum;
        protected bool hasEnded = false;
        protected bool initial = false;
        protected bool isDead = false;
        protected IDamageHandler _damageHandler;
        protected IActivityHandler _activityHandler;
        protected IHealHandler _healHandler;
        public bool HasEnded
        {
            get { return hasEnded; }
        }
        public abstract void Behaviour();
        public void AddDamageHandler(IDamageHandler pDamageHandler)
        {
            _damageHandler = pDamageHandler;
        }
        public void AddActivityHandler(IActivityHandler pActivityHandler)
        {
            _activityHandler = pActivityHandler;
        }
        public void AddHealHandler(IHealHandler pHealHandler)
        {
            _healHandler = pHealHandler;
        }
        public void SetPatientNum(int patientNum)
        {
            this.patientNum = patientNum;
        }
        
        public virtual void OnDeath(object sender, IEvent args)
        {
            isDead = ((DeathEvent)args).Dead[(PatientNum)patientNum];
            if (((DeathEvent)args).Dead[(PatientNum)patientNum])
            {
                hasEnded = true;
                initial = false;
            }
        }

        public virtual void OnGameEnd(object sender, IEvent args)
        {
            hasEnded = true;
            initial = false;
        }
    }
}
