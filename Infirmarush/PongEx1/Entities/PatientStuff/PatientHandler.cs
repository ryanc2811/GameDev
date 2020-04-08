using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;

namespace PongEx1.Entities.PatientStuff
{
    class PatientHandler : IPatientHandler, IDeathListener
    {
        IGameTimer Timer;
        public void AddGameTimer(IGameTimer gameTimer)
        {
            Timer = gameTimer;
        }

        public void OnDeath(object sender, IEvent args)
        {
           foreach(PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (((DeathEvent)args).Dead[num])
                {
                    Timer.OnTimerStart(5f);
                }
            }
        }
    }
}
