using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    public class Illness:IIllness
    {
        private IList<Symptom> symptoms;
        private BodyPart bodyPart;

        public BodyPart getBodyPart { get { return bodyPart; } }
        public IList<Symptom> getSymptoms { get { return symptoms; } }

        public Illness()
        {
            symptoms = new List<Symptom>();
        }
        public void addBodyPart(BodyPart bodyPart)
        {
            this.bodyPart = bodyPart;
        }

        public void addSymptom(Symptom symptom)
        {
            symptoms.Add(symptom);
            Console.WriteLine(symptom+" added");
        }
    }
}
