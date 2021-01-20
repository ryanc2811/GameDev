using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    /// <summary>
    /// GENERATES A NEW ILLNESS FOR THE PATIENT
    /// </summary>
    public class IllnessFactory : IIllnessFactory
    {
        /// <summary>
        /// CREATES THE ILLNESS
        /// </summary>
        /// <returns>NEW ILLNESS</returns>
        public IIllness create()
        {
            //INSTANTIATE THE ILLNESS
            IIllness illness = new Illness();
            //INSTANTIATE A RANDOM OBJECT
            Random rand = new Random();
            //SET THE TOTAL SYMPTOMS TO BE ADDED
            int totalSymptoms = rand.Next(1,3);
            //INSTANTIATE AN ILIST OF SYMPTOMS AND STORE EACH SYMPTOM IN THE LIST
            IList<Symptom> symptoms = Enum.GetValues(typeof(Symptom)).Cast<Symptom>().ToList();
            //INSTANTIATE AN ILIST OF SYMPTOMS AND STORE EACH BODYPART IN THE LIST
            IList<BodyPart> bodyParts = Enum.GetValues(typeof(BodyPart)).Cast<BodyPart>().ToList();
            //RANDOMLY SELECT WHICH BODY PART TO ADD
            int randBodyPart = rand.Next(bodyParts.Count);
            //ADD THE BODYPART TO THE ILLNESS
            illness.addBodyPart(bodyParts[randBodyPart]);
            //ITERATE OVER THE TOTAL SYMPTOMS THAT WILL BE ADDED
            for (int i = 0; i < totalSymptoms; i++)
            {
                //RANDOMLY SELECT A SYMPTOM
                int randSymptom= rand.Next(symptoms.Count);
                do
                {
                    //IF THE SYMPTOM DOES NOT MEET THE REQUIREMENTS OF AN ILLNESS, THEN GENERATE A NEW SYMPTOM
                    randSymptom = rand.Next(symptoms.Count);
                } while (symptoms[randSymptom] == Symptom.nausea && bodyParts[randBodyPart] == BodyPart.arm || symptoms[randSymptom] == Symptom.nausea && bodyParts[randBodyPart] == BodyPart.leg|| symptoms[randSymptom] == Symptom.infection && bodyParts[randBodyPart] == BodyPart.head);
                illness.addSymptom(symptoms[randSymptom]);
            }
            return illness;
        }
    }
}
