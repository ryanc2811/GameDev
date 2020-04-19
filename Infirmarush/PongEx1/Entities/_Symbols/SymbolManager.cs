using PongEx1.Entities.PatientStuff;
using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    class SymbolManager:ISymbolManager
    {
        private IDictionary<PatientNum, IIllness> illnessDict;
        IList<ISymbol> symbols;
        public SymbolManager()
        {
            illnessDict = new Dictionary<PatientNum, IIllness>();
            
        }
        public void AddSymbols(ISymbolHandler symbolHandler)
        {
            symbols = new List<ISymbol>();
            for (int i = 0; i < symbolHandler.Symbols.Count; i++)
            {
                if (!((ISymbol)symbolHandler.Symbols[i]).usedInHandbook)
                    symbols.Add((ISymbol)symbolHandler.Symbols[i]);

            }
        }
        public void AddIllness(IIllness illness, PatientNum patientNum)
        {
            illnessDict[patientNum] = illness;
            AlterSymbols(patientNum);
            
        }
        private void AlterSymbols(PatientNum patientNum)
        {
            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].Patient == patientNum)
                {
                    symbols[i].SetActive(false);
                }

            }
            IList<Symptom> symptoms = illnessDict[patientNum].getSymptoms;
            BodyPart bodyPart = illnessDict[patientNum].getBodyPart;
            Symptom symptom1=0;
            Symptom symptom2=0;
            for (int i = 0; i < symptoms.Count; i++)
            {
                if (i == 0)
                {
                    symptom1 = symptoms[i];
                }
                if (i == 1)
                {
                    symptom2 = symptoms[i];
                }
            }

            bool symbolAdded = false;
            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].SymbolType is SymbolType.Symptom)
                {
                  
                    ISymbol symbol = symbols[i];
                    if (symbol.Patient == patientNum)
                    {
                        if (!symbolAdded&&symptom1== ((ISymptomSymbol)symbol).Symptom)
                        {
                            symbol.SetActive(true);
                            symbolAdded = true;
                        }
                        else if(symbolAdded && symptoms.Count>1&&symptom2 == ((ISymptomSymbol)symbol).Symptom)
                        {
                            symbol.SetActive(true);
                        }
                    }
                    
                }
                if (symbols[i].SymbolType is SymbolType.BodyPart)
                {
                    ISymbol symbol = symbols[i];
                    if (bodyPart == ((IBodyPartSymbol)symbol).BodyPart)
                    {
                        if (symbol.Patient == patientNum)
                        {
                            symbol.SetActive(true);
                            
                        }
                    }
                }
            }
        }
    } }
