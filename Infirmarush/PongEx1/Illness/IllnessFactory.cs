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
            for (int i = 0; i < totalSymptoms; i++)
            {
                int randSymptom = rand.Next(symptoms.Count);
                illness.addSymptom(symptoms[randSymptom]);
            }
            int randBodyPart= rand.Next(bodyParts.Count);
            illness.addBodyPart(bodyParts[randBodyPart]);
            
            return illness;
        }
    }
}
