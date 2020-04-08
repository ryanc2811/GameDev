using PongEx1.Entities.PatientStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Damage
{
    public interface IDamageHandler
    {
        void OnTakeDamage(double damage,PatientNum patientNum);
    }
}
