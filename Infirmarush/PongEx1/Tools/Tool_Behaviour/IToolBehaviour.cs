using PongEx1.Activity;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Healing;

namespace PongEx1.Tools.Tool_Behaviour
{
    public interface IToolBehaviour
    {
        void AddDamageHandler(IDamageHandler pDamageHandler);
        void AddHealHandler(IHealHandler pHealHandler);
        void AddActivityHandler(IActivityHandler handler);
        void SetPatientNum(int patientNum);
        bool HasEnded { get; }
    }
}
