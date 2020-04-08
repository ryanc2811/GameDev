using PongEx1._Game.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    public interface IPatientHandler
    {
        void AddGameTimer(IGameTimer gameTimer);
    }
}
