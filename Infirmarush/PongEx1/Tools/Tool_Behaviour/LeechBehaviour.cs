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
    class LeechBehaviour : ToolBehaviour,IInteractListener
    {
        int timeBetweenDamage = 0;
        int timeBetweenHeal = 0;
        int leechPoints = 0;
        bool interacted = false;
        bool leechActive = false;
        bool gotInput = false;
        int maxLeechPoints = 1600;
        public override void Behaviour()
        {
            if (!initial)
            {
                leechPoints = 0;
                //timer starts
                initial = true;
                hasEnded = false;
                _activityHandler.OnActivityEnd(false, (PatientNum)patientNum);
                leechActive = false;
            }
            
            if (leechPoints > maxLeechPoints)
            {
                isActive = false;
                initial = false;
                hasEnded = true;
                _activityHandler.OnActivityEnd(true, (PatientNum)patientNum);
                Console.WriteLine((PatientNum) patientNum+" is Cured");
            }
            
            if (leechActive)
            {
                leechPoints++;
                
                if (timeBetweenDamage < 30)
                {
                    timeBetweenDamage++;
                }
                else
                {
                    _damageHandler.OnTakeDamage(0.015, (PatientNum)patientNum);
                    timeBetweenDamage = 0;
                }  
            }
            else if(!leechActive && !isDead)
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
            if (interacted&&!gotInput)
            {
                leechActive = !leechActive;
                gotInput = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                gotInput = false;
            }
        }

        public void OnInteract(object sender, IEvent args)
        {
            interacted =((InteractedEvent)args).Interacted[(PatientNum)patientNum];
        }
        public override void OnGameEnd(object sender, IEvent args)
        {
            base.OnGameEnd(sender, args);
            leechPoints = 0;
            leechActive = false;
            isActive = false;
        }
    }
}
