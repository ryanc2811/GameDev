using PongEx1._Game.Events;
using PongEx1.Entities.Interacted;
using PongEx1.Entities.PatientStuff;
using System;

namespace PongEx1.Tools.Tool_Behaviour
{
    /// <summary>
    /// BEHAVIOUR OF THE LEECH TOOL
    /// </summary>
    class LeechBehaviour : ToolBehaviour,IInteractListener
    {
        #region DATAMEMBERS
        //DECLARE AN INT FOR COUNTER THE TIME BETWEEN EACH DAMAGE CALL, SO THAT IT IS NOT CALLED EVERY FRAME
        int timeBetweenDamage = 0;
        //DECLARE AN INT FOR COUNTER THE TIME BETWEEN EACH HEAL CALL, SO THAT IT IS NOT CALLED EVERY FRAME
        int timeBetweenHeal = 0;
        //DECLARE AN INT FOR COUNTING THE LEECH POINTS, WHICH ONLY INCREASE WHILE THE PATIENT IS TAKING DAMAGE
        int leechPoints = 0;
        //DECLARE A BOOLEAN FOR CHECKING IF THE LEECH IS ACTIVE
        bool leechActive = false;
        //DECLARE AN INT FOR STORING THE TOTAL SCORE, THAT THE LEECH POINT MUST REACH BEFORE CURING THE PATIENT
        int maxLeechPoints = 900;
        #endregion
        #region BEHAVIOUR
        /// <summary>
        /// RUNS THE BEHAVIOUR OF THE LEECH TOOL
        /// </summary>
        public override void Behaviour()
        {
            //ON THE FIRST FRAME OF BEHAVIOUR
            if (!initial)
            {
                //RESET LEECH POINTS
                leechPoints = 0;
                initial = true;
                //RESET HAS ENDED BOOLEAN
                hasEnded = false;
                //SEND DATA TO THE ACTIVITY HANDLER
                _activityHandler.OnActivityEnd(false, (PatientNum)patientNum);
                //RESET LEECH ACTIVE BOOLEAN
                leechActive = true;
            }
            //IF PATIENT IS CURED
            if (leechPoints > maxLeechPoints)
            {
                //RESET BOOLEANS
                isActive = false;
                initial = false;
                hasEnded = true;
                //SEND DATA TO ACTIVITY HANDLER
                _activityHandler.OnActivityEnd(true, (PatientNum)patientNum);
                Console.WriteLine((PatientNum) patientNum+" is Cured");
            }
            //IF THE LEECH IS ACTIVE
            if (leechActive)
            {
                //ADD TO THE LEECH POINTS
                leechPoints++;
                //COUNT BETWEEN EACH DAMAGE
                if (timeBetweenDamage < 30)
                {
                    timeBetweenDamage++;
                }
                else
                {
                    //PATIENT TAKES DAMAGE
                    _damageHandler.OnTakeDamage(0.03, (PatientNum)patientNum);
                    //RESET COUNTER
                    timeBetweenDamage = 0;
                }  
            }
            //IF THE LEECH IS NOT ACTIVE AND THE PATIENT IS NOT DEAD
            else if(!leechActive && !isDead)
            {
                //COUNT BETWEEN EACH HEAL
                if (timeBetweenHeal < 30)
                {
                    timeBetweenHeal++;
                }
                else
                {
                    //HEAL THE PATIENT
                    _healHandler.OnHeal(0.03, (PatientNum)patientNum);
                    //RESET THE COUNTER
                    timeBetweenHeal = 0;
                }
            }   
        }
        /// <summary>
        /// Set the leech active/inactive
        /// </summary>
        private void Interact()
        {
            //LEECH ACTIVE IS THE OPPOSITE VALUE OF ITSELF
            leechActive = !leechActive;
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR THE INTERACT EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnInteract(object sender, IEvent args)
        {
            //SET THE INTERACT BOOLEAN LOCALLY
            if (((InteractedEvent)args).Interacted[(PatientNum)patientNum])
                Interact();
        }
        /// <summary>
        /// LISTENS FOR THE GAME END EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnGameEnd(object sender, IEvent args)
        {
            base.OnGameEnd(sender, args);
            //RESET LEECH POINTS
            leechPoints = 0;
            //RESET LEECH BOOLEAN
            leechActive = false;
            //RESET IS BEHAVIOUR ACTIVE BOOLEAN
            isActive = false;
        }
    }
    #endregion
}
