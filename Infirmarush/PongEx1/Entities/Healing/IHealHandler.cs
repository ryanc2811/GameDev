using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    /// <summary>
    /// Interface for the healhandler, which handles the Heal event
    /// </summary>
    public interface IHealHandler
    {
        /// <summary>
        /// triggered when a class wants to heal a patient
        /// </summary>
        void OnHeal(double heal,PatientNum patientNum);
    }
}
