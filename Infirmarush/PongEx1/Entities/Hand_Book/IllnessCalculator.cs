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
    /// <summary>
    /// Calculates which tool should be used by the player
    /// </summary>
    class IllnessCalculator: IIllnessCalculator
    {
        //DECLARE A REFERENCE TO THE TOOL SYMBOLS
        private IEntity bonesaw,leech;
        /// <summary>
        /// Add the tool symbol to the illness calculator
        /// </summary>
        /// <param name="Tool"></param>
        public void AddToolSymbol(IEntity Tool)
        {
            if (((IToolSymbol)Tool).Tool is Tools.ToolType.leech)
                leech = Tool;
            else if (((IToolSymbol)Tool).Tool is Tools.ToolType.bonesaw)
                bonesaw = Tool;
        }
        /// <summary>
        /// Calculate which tool symbol shall be returned with the given parameters
        /// </summary>
        /// <param name="symbolSlot1"></param>
        /// <param name="symbolSlot2"></param>
        /// <param name="bodyPartSymbol"></param>
        /// <returns></returns>
        public IEntity CalculateIllness(ISymptomSymbol symbolSlot1, ISymptomSymbol symbolSlot2, IBodyPartSymbol bodyPartSymbol)
        {
            //if the symbol slot is full and the body part slot is full
            if (symbolSlot1 != null && bodyPartSymbol != null)
            {
                //if the symbol slot 1 symptom is an infection and the body part is a leg or an arm
                if (symbolSlot1.Symptom == Symptom.infection&& bodyPartSymbol.BodyPart == BodyPart.leg || symbolSlot1.Symptom == Symptom.infection && bodyPartSymbol.BodyPart == BodyPart.arm)
                {
                    //if the symbol slot 2 is not null and the symbols symptom is infection
                    if (symbolSlot2 != null && symbolSlot2.Symptom == Symptom.infection)
                    {
                        //there is two infection symbols in the calculator
                        Console.WriteLine("InfectionX2");
                        //set the leech position off screen
                        leech.setPosition(1111, 1111);
                        //return the bonesaw symbol
                        return bonesaw;
                    }
                    //there is one infection in the calculator
                    Console.WriteLine("InfectionX1");
                    //set the leech symbol off screen
                    leech.setPosition(1111, 1111);
                    //return the bonesaw symbol
                    return bonesaw;
                }
                //else if the symbol symptom is nausea and the body part is a head
                else if (symbolSlot1.Symptom == Symptom.nausea && bodyPartSymbol.BodyPart == BodyPart.head)
                {
                    //if the symptom slot 2 is occupied and the symptom of the symbol is nausea
                    if (symbolSlot2 != null && symbolSlot2.Symptom == Symptom.nausea)
                    {
                        //there is two nausea symbols in the calculator
                        Console.WriteLine("NauseaX2");
                        //set the bonesaw symbol offscreen
                        bonesaw.setPosition(1111, 1111);
                        //return the leech
                        return leech;
                    }
                    //there is one nausea symbol in the calculator
                    Console.WriteLine("NauseaX1");
                    //set the bonesaw symbol offscreen
                    bonesaw.setPosition(1111, 1111);
                    //return the leech symbol
                    return leech;
                }
            }

            return null;
         
        }
    }
}
