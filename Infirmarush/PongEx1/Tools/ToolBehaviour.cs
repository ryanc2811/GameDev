using PongEx1._Game.Events;
using PongEx1.Activity;
using PongEx1.Entities.Damage;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public abstract class ToolBehaviour : IBehaviour,IDeathListener
    {
        protected bool isActive = false;
        protected int patientNum;
        protected bool hasEnded = false;
        protected bool initial = false;
        protected IDamageHandler _damageHandler;
        protected IActivityHandler _activityHandler;
        public bool HasEnded
        {
            get { return hasEnded; }
            set { hasEnded = value; }
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
        public void SetPatientNum(int patientNum)
        {
            this.patientNum = patientNum;
        }
        
        public void OnDeath(object sender, IEvent args)
        {
            if (((DeathEvent)args).Dead[(PatientNum)patientNum])
            {
                _activityHandler.OnActivityChange(false, (PatientNum)patientNum);
                hasEnded = true;
                initial = false;
            }
        }
    }
}
