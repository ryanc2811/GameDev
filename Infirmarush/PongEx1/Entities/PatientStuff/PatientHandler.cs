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
    class PatientHandler : IPatientHandler, IDeathListener,IActivityListener
    {
        IDictionary<PatientNum, IGameTimer> Timers;
        public PatientHandler()
        {
            Timers = new Dictionary<PatientNum, IGameTimer>();
        }
        public void AddGameTimer(IGameTimer gameTimer,PatientNum num)
        {
            Timers[num] = gameTimer;
        }
        public void OnActivityEnd(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (((ActivityEvent)args).Ended[num])
                {
                    Timers[num].OnTimerStart(5f,num);
                }
            }
        }

        public void OnDeath(object sender, IEvent args)
        {
           foreach(PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (((DeathEvent)args).Dead[num])
                {
                    Timers[num].OnTimerStart(5f,num);
                }
            }
        }
    }
}
