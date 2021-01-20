using PongEx1._Game.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    /// <summary>
    /// INTERFACE FOR THE TOOL OBJECT, WHICH IS USED TO CURE PATIENTS
    /// </summary>
    public interface ITool
    {
        /// <summary>
        /// GETTER FOR THE NAME OF THE TOOL
        /// </summary>
        string GetName { get; }
        /// <summary>
        /// SETS THE TOOL ACTIVE
        /// </summary>
        /// <param name="active"></param>
        /// <param name="PatientNum"></param>
        void SetActive(bool active,int PatientNum);
        /// <summary>
        /// SETTER FOR THE BEHAVIOUR OF THE TOOL
        /// </summary>
        /// <param name="behaviour"></param>
        /// <param name="patientNum"></param>
        void ReceiveJob(IBehaviour behaviour,int patientNum);
        /// <summary>
        /// UPDATES THE TOOL
        /// </summary>
        void Update();
    }
}
