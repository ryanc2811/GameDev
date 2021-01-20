using PongEx1.Activity;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Healing;

namespace PongEx1.Tools.Tool_Behaviour
{
    /// <summary>
    /// INTERFACE FOR ALL TOOL BEHAVIOURS
    /// </summary>
    public interface IToolBehaviour
    {
        /// <summary>
        /// SETTER FOR THE DAMAGE HANDLER
        /// </summary>
        /// <param name="pDamageHandler"></param>
        void AddDamageHandler(IDamageHandler pDamageHandler);
        /// <summary>
        /// SETTER FOR THE HEAL HANDLER
        /// </summary>
        /// <param name="pHealHandler"></param>
        void AddHealHandler(IHealHandler pHealHandler);
        /// <summary>
        /// SETTER FOR THE ACTIVITY HANDLER
        /// </summary>
        /// <param name="handler"></param>
        void AddActivityHandler(IActivityHandler handler);
        /// <summary>
        /// SETTER FOR THE PATIENT NUMBER THAT THE ACTIVITY IS ASSOCIATED WITH
        /// </summary>
        /// <param name="patientNum"></param>
        void SetPatientNum(int patientNum);
        /// <summary>
        /// GETTER FOTR THE HAS ENDED BOOLEAN
        /// </summary>
        bool HasEnded { get; }
    }
}
