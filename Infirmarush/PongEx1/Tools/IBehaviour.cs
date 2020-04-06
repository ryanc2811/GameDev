using PongEx1.Activity;
using PongEx1.Entities.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public interface IBehaviour
    {
        void Behaviour();
        void AddDamageHandler(IDamageHandler pDamageHandler);
        void AddActivityHandler(IActivityHandler handler);
        void SetPatientNum(int patientNum);
        bool HasEnded { get; set; }
    }
}
