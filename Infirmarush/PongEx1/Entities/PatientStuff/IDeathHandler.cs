using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.PatientStuff
{
    public interface IDeathHandler
    {
        //Update 
        void OnDeath(bool isDead, PatientNum patientNum);
    }
}
