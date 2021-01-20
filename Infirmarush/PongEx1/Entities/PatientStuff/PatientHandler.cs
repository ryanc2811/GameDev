using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// HANDLES THE PATIENTS DEATH AND CURED STATE
    /// </summary>
    class PatientHandler : IPatientHandler, IDeathListener,IActivityListener
    {
        //DECLARE AN IDICTIONARY FOR THE RESPAWN TIMERS
        IDictionary<PatientNum, IGameTimer> Timers;
        public PatientHandler()
        {
            //INSTANTIATE THE TIMERS DICTIONARY
            Timers = new Dictionary<PatientNum, IGameTimer>();
        }
        #region ADD GAME TIMER
        /// <summary>
        /// ADD THE RESPAWN TIMER TO THE PATIENT HANDLER
        /// </summary>
        /// <param name="gameTimer"></param>
        /// <param name="num"></param>
        public void AddGameTimer(IGameTimer gameTimer,PatientNum num)
        {
            Timers[num] = gameTimer;
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR THE ACTIVITY TO END
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnActivityEnd(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //IF A PATIENT IS CURED START THE TIMER FOR THAT PATIENT
                if (((ActivityEvent)args).Ended[num])
                {
                    Timers[num].OnTimerStart(5f,num);
                }
            }
        }
        /// <summary>
        /// LISTENS FOR A PATIENT TO DIE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDeath(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //IF A PATIENT IS DEAD, START A TIMER FOR THAT PATIENT
                if (((DeathEvent)args).Dead[num])
                {
                    Timers[num].OnTimerStart(5f,num);
                }
            }
        }
        #endregion
    }
}
