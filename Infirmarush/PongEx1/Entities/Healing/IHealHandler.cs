using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Healing
{
    public interface IHealHandler
    {
        void OnHeal(double heal,PatientNum patientNum);
    }
}
