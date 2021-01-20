using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Interacted
{
    /// <summary>
    /// Handles the Interact event
    /// </summary>
    public interface IInteractHandler
    {
        /// <summary>
        /// Triggered when player interacts with the patient
        /// handles the interact event
        /// </summary>
        /// <param name="interact"></param>
        /// <param name="patientNum"></param>
        void OnInteract(bool interact, PatientNum patientNum);
    }
}
