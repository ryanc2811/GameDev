using Microsoft.Xna.Framework.Input;
using PongEx1._Game.Behaviour;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Entities.Interacted;
using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools.Tool_Behaviour
{
    class LeechBehaviour : ToolBehaviour,IGameTimerListener,IInteractListener
    {
        IGameTimer Timer;
        bool timerEnded=false;
        int timeBetweenDamage = 0;
        int timeBetweenHeal = 0;
        int leechPoints = 0;
        bool interacted = false;
        bool timerPaused = false;
        
        public void AddGameTimer(IGameTimer gameTimer)
        {
            Timer = gameTimer;
        }
        public override void Behaviour()
        {

            
            //
            if (!initial)
            {
                leechPoints = 0;
                //timer starts
                Timer.OnTimerStart(15f, (PatientNum)patientNum);
                initial = true;
                hasEnded = false;
                _activityHandler.OnActivityChange(true, (PatientNum)patientNum);
                timerPaused = true;
            }
           
            if (leechPoints > 4000)
            {
                isActive = false;
                initial = false;
                hasEnded = true;
                _activityHandler.OnActivityChange(false, (PatientNum)patientNum);
                Console.WriteLine((PatientNum) patientNum+" is Cured");
            }
            
            if (!timerEnded&&!timerPaused)
            {
                leechPoints++;
                
                if (timeBetweenDamage < 30)
                {
                    timeBetweenDamage++;
                }
                else
                {
                    _damageHandler.OnTakeDamage(0.01, (PatientNum)patientNum);
                    timeBetweenDamage = 0;
                }  
            }
            else if(timerEnded||timerPaused)
            {
                if (timeBetweenHeal < 30)
                {
                    timeBetweenHeal++;
                }
                else
                {
                    _healHandler.OnHeal(0.01, (PatientNum)patientNum);
                    timeBetweenHeal = 0;
                }
            }
            if (interacted && !timerEnded)
            {
                timerPaused = !timerPaused;
                Timer.OnTimerPause(timerPaused);
            }
            else if (interacted && timerEnded)
            {
                Timer.OnTimerStart(15f,(PatientNum)patientNum);
                Timer.OnTimerPause(false);
            }
            

        }

        public void OnInteract(object sender, IEvent args)
        {
            interacted=((InteractedEvent)args).Interacted[(PatientNum)patientNum];
        }

        public void OnTimerStart(object sender, IEvent args)
        {
            timerEnded = ((TimerEvent)args).DictTimerEnd[(PatientNum)patientNum];
        }
    }
}
