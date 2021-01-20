using PongEx1.Entities.PatientStuff;
using PongEx1.Illness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities._Symbols
{
    /// <summary>
    /// Manages the symbols in the game
    /// </summary>
    class SymbolManager:ISymbolManager
    {
        //DECLARE an IDictionary that stores the illness and the patient that the illness belongs to
        private IDictionary<PatientNum, IIllness> illnessDict;
        //DECLARE an IList that stores all the symbols locally
        IList<ISymbol> symbols;
        public SymbolManager()
        {
            illnessDict = new Dictionary<PatientNum, IIllness>();
        }
        /// <summary>
        /// Adds the symbols to the local symbol list
        /// </summary>
        /// <param name="symbolHandler"></param>
        public void AddSymbols(ISymbolHandler symbolHandler)
        {
            symbols = new List<ISymbol>();
            for (int i = 0; i < symbolHandler.Symbols.Count; i++)
            {
                //if the symbol is not being used the handbook then add the symbol to the symbols list
                if (!((ISymbol)symbolHandler.Symbols[i]).usedInHandbook)
                    symbols.Add((ISymbol)symbolHandler.Symbols[i]);

            }
        }
        /// <summary>
        /// Add the illness to the symbol manager
        /// </summary>
        /// <param name="illness"></param>
        /// <param name="patientNum"></param>
        public void AddIllness(IIllness illness, PatientNum patientNum)
        {
            //Set the illness in the illnessDict to the passed value
            illnessDict[patientNum] = illness;
            //alter the symbols on the scene that correspond to the passed patient number
            AlterSymbols(patientNum);
            
        }
        /// <summary>
        /// Alter the symbols on the scene that correspond to the passed patient number
        /// </summary>
        /// <param name="patientNum"></param>
        private void AlterSymbols(PatientNum patientNum)
        {
            //iterate through the symbols list
            for (int i = 0; i < symbols.Count; i++)
            {
                //if the symbols patient num is equal to the passed value then set the symbol to be inactive
                if (symbols[i].Patient == patientNum)
                {
                    symbols[i].SetActive(false);
                }

            }
            //create a tempory IList that stores the symptoms from the illness in the illness dictionary
            IList<Symptom> symptoms = illnessDict[patientNum].getSymptoms;
            //create a temporary BodyPart that stores the body part from he illness in the illness dictionary
            BodyPart bodyPart = illnessDict[patientNum].getBodyPart;
            //DECLARE a Symptom and set the default value to 0
            Symptom symptom1=0;
            Symptom symptom2=0;
            for (int i = 0; i < symptoms.Count; i++)
            {
                if (i == 0)
                {
                    //set the symptom to the symptom at the current index
                    symptom1 = symptoms[i];
                }
                if (i == 1)
                {
                    //set the symptom to the symptom at the current index
                    symptom2 = symptoms[i];
                }
            }
            //DECLARE a boolean for checking if the symbol has been added to the scene
            bool symbolAdded = false;
            for (int i = 0; i < symbols.Count; i++)
            {
                if (symbols[i].SymbolType is SymbolType.Symptom)
                {
                    //cache the symbol in a temporary variable
                    ISymbol symbol = symbols[i];
                    if (symbol.Patient == patientNum)
                    {
                        //if a symbol has not been added to the scene and the symptom1 equals to the temp symbol variables symptom
                        if (!symbolAdded&&symptom1== ((ISymptomSymbol)symbol).Symptom)
                        {
                            //set the symbol active
                            symbol.SetActive(true);
                            //flag the symbol as being added
                            symbolAdded = true;
                        }
                        //if a symbol has been added and there is more that one symptom in the symptoms list
                        else if(symbolAdded && symptoms.Count>1&&symptom2 == ((ISymptomSymbol)symbol).Symptom)
                        {
                            //set the symbol active
                            symbol.SetActive(true);
                        }
                    }
                    
                }
                //if the symbol is a body part symbol
                if (symbols[i].SymbolType is SymbolType.BodyPart)
                {
                    //cache the symbol
                    ISymbol symbol = symbols[i];
                    if (bodyPart == ((IBodyPartSymbol)symbol).BodyPart)
                    {
                        if (symbol.Patient == patientNum)
                        {
                            //set the symbol active
                            symbol.SetActive(true);
                        }
                    }
                }
            }
        }
    } }
