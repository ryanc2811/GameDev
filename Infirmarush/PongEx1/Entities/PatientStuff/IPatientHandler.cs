using PongEx1._Game.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// INTERFACE FOR THE PATIENT HANDLER, WHICH HANDLES WHAT HAPPENS WHEN A PATIENT DIES AND WHEN A PATIENT IS CURED
    /// </summary>
    public interface IPatientHandler
    {
        /// <summary>
        /// ADDS A GAME TIMER HANDLER TO THE PATIENT HANDLER
        /// </summary>
        /// <param name="gameTimer"></param>
        /// <param name="num"></param>
        void AddGameTimer(IGameTimer gameTimer, PatientNum num);
    }
}
