using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    /// <summary>
    /// interface for the handler class that handles the Damage event
    /// </summary>
    public interface IDamageHandler
    {
        /// <summary>
        /// handles the damage event
        /// </summary>
        /// <param name="damage"></param>
        /// <param name="patientNum"></param>
        void OnTakeDamage(double damage,PatientNum patientNum);
    }
}
