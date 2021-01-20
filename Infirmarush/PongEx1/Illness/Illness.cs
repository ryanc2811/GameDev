using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    /// <summary>
    /// CONTAINS INFORMATION ABOUT A PATIENTS ILLNESS
    /// </summary>
    public class Illness:IIllness
    {
        #region DATA MEMBERS
        //DECLARE AN ILIST FOR STORING THE SYMTOMS OF AN ILLNESS
        private IList<Symptom> symptoms;
        //DECLARE A BODYPART FOR STORING THE BODYPART THAT THE ILLNESS IS ASSOCITATED WITH
        private BodyPart bodyPart;
        #endregion
        #region PROPERTIES
        /// <summary>
        /// GETS THE BODY PART
        /// </summary>
        public BodyPart getBodyPart { get { return bodyPart; } }
        /// <summary>
        /// GETS THE SYMPTOMS
        /// </summary>
        public IList<Symptom> getSymptoms { get { return symptoms; } }
        /// <summary>
        /// SETTER FOR THE BODY PART
        /// </summary>
        /// <param name="bodyPart"></param>
        public void addBodyPart(BodyPart bodyPart)
        {
            this.bodyPart = bodyPart;
        }
        /// <summary>
        /// SETTER FOR THE SYMPTOM
        /// </summary>
        /// <param name="symptom"></param>
        public void addSymptom(Symptom symptom)
        {
            symptoms.Add(symptom);
            Console.WriteLine(symptom + " added");
        }
        #endregion
        #region CONSTRUCTOR
        public Illness()
        {
            //INSTANTIATE THE SYMPTOMS LIST
            symptoms = new List<Symptom>();
        }
        #endregion
    }
}
