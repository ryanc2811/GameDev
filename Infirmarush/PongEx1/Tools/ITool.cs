using PongEx1._Game.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    public interface ITool
    {
        string GetName { get; }
        void setActive(bool active,int PatientNum);
        void receiveJob(IBehaviour behaviour,int patientNum);
        void Update();
    }
}
