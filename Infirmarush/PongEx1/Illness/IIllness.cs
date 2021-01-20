using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    /// <summary>
    /// INTERFACE FOR THE ILLNESS OBJECT, WHICH HOLDS INFORMATION ABOUT THE ILLNESS
    /// </summary>
    public interface IIllness
    {
        /// <summary>
        /// GETTER FOR THE BODY PART
        /// </summary>
        BodyPart getBodyPart { get; }
        /// <summary>
        /// GETTER FOR THE SYMPTOMS
        /// </summary>
        IList<Symptom> getSymptoms { get; }
        /// <summary>
        /// SETTER FOR THE BODY PART
        /// </summary>
        /// <param name="bodyPart"></param>
        void addBodyPart(BodyPart bodyPart);
        /// <summary>
        /// SETTER FOR THE SYMPTOM
        /// </summary>
        /// <param name="symptom"></param>
        void addSymptom(Symptom symptom);
    }
}
