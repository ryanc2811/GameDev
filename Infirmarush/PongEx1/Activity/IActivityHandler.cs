using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    /// <summary>
    /// interface for the handler class that handles the Activity event
    /// </summary>
    public interface IActivityHandler
    {
        /// <summary>
        /// Handles the event
        /// </summary>
        /// <param name="ended"></param>
        /// <param name="patientNum"></param>
        void OnActivityEnd(bool ended, PatientNum patientNum);
    }
}
