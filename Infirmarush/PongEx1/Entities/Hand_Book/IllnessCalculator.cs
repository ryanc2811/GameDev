using PongEx1.Entities._Symbols;
using PongEx1.Game_Engine.Entities;
using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities.Hand_Book
{
    class IllnessCalculator: IIllnessCalculator
    {
        IEntity bonesaw;
        IEntity leech;
        public void AddToolSymbol(IEntity Tool)
        {
            if (((IToolSymbol)Tool).Tool is Tools.ToolType.leech)
                leech = Tool;
            else if (((IToolSymbol)Tool).Tool is Tools.ToolType.bonesaw)
                bonesaw = Tool;
        }
        public IEntity CalculateIllness(ISymptomSymbol symbolSlot1, ISymptomSymbol symbolSlot2, IBodyPartSymbol bodyPartSymbol)
        {
            if (symbolSlot1 != null && bodyPartSymbol != null)
            {
              
                if (symbolSlot1.Symptom == Symptom.infection&& bodyPartSymbol.BodyPart == BodyPart.leg || symbolSlot1.Symptom == Symptom.infection && bodyPartSymbol.BodyPart == BodyPart.arm)
                {
                    if (symbolSlot2 != null&& symbolSlot2.Symptom == Symptom.infection)
                    {
                        Console.WriteLine("InfectionX2");
                        leech.setPosition(1111, 1111);
                        return bonesaw;
                    }
                    Console.WriteLine("InfectionX1");
                    leech.setPosition(1111, 1111);
                    return bonesaw;
                }
                else if (symbolSlot1.Symptom == Symptom.nausea && bodyPartSymbol.BodyPart == BodyPart.head)
                {
                    if (symbolSlot2 != null && symbolSlot2.Symptom == Symptom.nausea)
                    {
                        Console.WriteLine("NauseaX2");
                        bonesaw.setPosition(1111, 1111);
                        return leech;
                    }
                    Console.WriteLine("NauseaX1");
                    bonesaw.setPosition(1111, 1111);
                    return leech;
                }
            }

            return null;
         
        }
    }
}
