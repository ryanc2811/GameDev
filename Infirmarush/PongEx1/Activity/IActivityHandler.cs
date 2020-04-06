using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    public interface IActivityHandler
    {
       
        void OnActivityChange(bool isActive,PatientNum patientNum);
    }
}
