using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    /// <summary>
    /// HANDLES THE DEATH EVENT OF THE PATIENT
    /// </summary>
    public interface IDeathHandler
    {
        /// <summary>
        /// TRIGGERED WHEN A PATIENT DIES
        /// HANDLES THE DEATH EVENT
        /// </summary>
        /// <param name="isDead"></param>
        /// <param name="patientNum"></param>
        void OnDeath(bool isDead, PatientNum patientNum);
    }
}
