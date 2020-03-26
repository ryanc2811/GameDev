using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    public class IllnessFactory : IIllnessFactory
    {
        public IIllness create()
        {
            IIllness illness = new Illness();
            Random rand = new Random();
            int totalSymptoms = rand.Next(1,3);
            IList<Symptom> symptoms = Enum.GetValues(typeof(Symptom)).Cast<Symptom>().ToList();
            IList<BodyPart> bodyParts = Enum.GetValues(typeof(BodyPart)).Cast<BodyPart>().ToList();
            int randBodyPart = rand.Next(bodyParts.Count);
            illness.addBodyPart(bodyParts[randBodyPart]);
            for (int i = 0; i < totalSymptoms; i++)
            {
                int randSymptom= rand.Next(symptoms.Count);
                do
                {
                    randSymptom = rand.Next(symptoms.Count);
                } while (symptoms[randSymptom] == Symptom.nausea && bodyParts[randBodyPart] == BodyPart.arm || symptoms[randSymptom] == Symptom.nausea && bodyParts[randBodyPart] == BodyPart.leg);
                illness.addSymptom(symptoms[randSymptom]);
            }
            return illness;
        }
    }
}
