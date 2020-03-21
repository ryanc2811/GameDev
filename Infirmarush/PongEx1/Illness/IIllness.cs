using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Illness
{
    public interface IIllness
    {
        BodyPart getBodyPart { get; }
        List<Symptom> getSymptoms { get; }
        void addBodyPart(BodyPart bodyPart);
        void addSymptom(Symptom bodyPart);
    }
}
