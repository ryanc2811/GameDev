using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Entities._Symbols;
using PongEx1.Entities.Button;
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
    /// Updates the illness calculator and the symbols that sit inside the handbook
    /// </summary>
    class HandBook:GameXEntity,IHandBook
    {
        #region data members
        //DECLARE AN ILIST FOR STORING ISYMBOLS
        private IList<ISymbol> symbols;
        //DECLARE A REFERENCE TO THE SYMBOL HANDLER
        private ISymbolHandler symbolHandler;
        //DECLARE A REFERENCE TO THE ILLNESS CALCULATOR
        private IIllnessCalculator illnessCalculator;
        //DECLARE AN IDICTIONARY FOR STORING THE SYMPTOM BUTTONS AND THE SYMPTOM TYPE THAT IT IS
        private IDictionary<Symptom, IButton> symptomButtons;
        //DECLARE AN IDICTIONARY FOR STORING THE BODY BUTTONS AND THE BODY PART TYPE THAT IT IS
        private IDictionary<BodyPart, IButton> bodyPartButtons;
        //DECLARE AN IENTITY FOR STORING THE TOOL SYMBOL THAT SITS IN THE TOOL SLOT OF THE CALCULATOR
        private IEntity toolSlot;
        //DECLARE A REFERENCE TO THE HANDBOOK BUTTON THAT WHEN CLICK, SET THE HANDBOOK TO BE ACTIVE
        private IButton handBookBtn;
        //DECLARE A REFERENCE TO THE RESET BUTTON THAT RESETS THE CONTENTS OF THE ILLNESS CALCULATOR
        private IButton resetBtn;
        //DECLARE AN ISYMBOL FOR EACH OF THE SYMBOL SLOTS AND BODYPART SLOT ON THE CALCULATOR
        private ISymbol symbolSlot1, symbolSlot2, bodyPartSlot;
        //DECLARE AN INT FOR COUNTING THE AMOUNT OF BUTTONS THAT HAVE BEEN ADDED TO THE HANDBOOK
        private int symptomButtonCounter=-1, bodyPartButtonCounter = -1;
        //DECLARE AN INT FOR COUNTING THE AMOUNT OF SYMBOLS THAT HAVE BEEN ADDED TO THE HANDBOOK
        private int symbAddedToCalcCount = 0;
        //DECLARE A BOOL FOR CHECKING IF THE SYMBOL HAS BEEN ADDED TO THE CALCULATOR
        private bool addedToCalc=false;
        //DECLARE A BOOL FOR CHECKING IF THE HANDBOOK IS ACTIVE
        private bool isActive = false;
        //DECLARE A BOOL FOR CHECKING IF THE HANDBOOK BUTTON INPUT HAS BEEN TAKEN
        private bool gotInput = false;
        //DECLARE A VECTOR2 ARRAY FOR STORING THE POSITIONS OF THE BUTTONS FOR WHEN THE HANDBOOK IS ACTIVE
        private Vector2[] symptomButtonPos = { new Vector2(375, 275), new Vector2(375, 375) };
        private Vector2[] bodyPartButtonPos = { new Vector2(900, 550), new Vector2(1000, 550), new Vector2(1100, 550) };
        //DECLARE A VECTOR2 FOR STORING THE POSITION OF THE HANDBOOK FOR WHEN THE HANDBOOK IS ACTIVE
        private Vector2 activePos=new Vector2(325, 100);
        //DECLARE A BOOLEAN THAT FLAGS WHEN THE HANDBOOK HAS FIRST BEEN INTIALISED
        bool initial = false;
        #endregion
        public HandBook()
        {
            //set the layer depth of the handbook so that the handbook sits underneath all the handbook entities, but above the game entities such as player and patient
            layerDepth = 0.1f;
            //INITIALISE the symbols list
            symbols = new List<ISymbol>();
            //INITIALISE the dictionaries
            symptomButtons = new Dictionary<Symptom,IButton>();
            bodyPartButtons = new Dictionary<BodyPart,IButton>();

        }
        #region add buttons
        /// <summary>
        /// adds the button that resets the calculator to the handbook
        /// </summary>
        /// <param name="resetButton"></param>
        public void AddResetButton(IButton resetButton)
        {
            resetBtn = resetButton;
        }
        /// <summary>
        /// adds the button that sets the handbook active and inactive
        /// </summary>
        /// <param name="handBookButton"></param>
        public void AddHandBookButton(IButton handBookButton)
        {
            handBookBtn = handBookButton;
        }
        /// <summary>
        /// Adds the button that adds a symbol to the calculator
        /// </summary>
        /// <param name="symbolType"></param>
        /// <param name="symbolButton"></param>
        public void AddSymbolButton(SymbolType symbolType,IButton symbolButton)
        {
            //if the passed symbol type is body part
            if(symbolType is SymbolType.BodyPart)
            {
                //add one to the counter
                bodyPartButtonCounter++;
                //populate the bodypart buttons dictionary with the passed button
                bodyPartButtons[(BodyPart)bodyPartButtonCounter] = symbolButton;
            }
            else if (symbolType is SymbolType.Symptom)
            {
                //add one to the counter
                symptomButtonCounter++;
                //populate the symptom buttons dictionary with the passed button
                symptomButtons[(Symptom)symptomButtonCounter] = symbolButton;
            }
        }
        #endregion
        #region add symbol handler
        /// <summary>
        /// adds the symbol handler, which contains a reference to all the symbols in the game
        /// </summary>
        /// <param name="symbolHandler"></param>
        public void AddSymbolHandler(ISymbolHandler symbolHandler)
        {
            this.symbolHandler = symbolHandler;
        }
        #endregion
        #region add illness calculator
        /// <summary>
        /// Adds the illness calculator, which calculates the tool that the player must use with a list of symptoms and body parts
        /// </summary>
        /// <param name="illnessCalculator"></param>
        public void AddIllnessCalculator(IIllnessCalculator illnessCalculator)
        {
            this.illnessCalculator = illnessCalculator;
        }
        #endregion
        #region Reset Position of symbols
        /// <summary>
        /// Resets the position of each entity in the handbook 
        /// </summary>
        private void ResetPosition()
        {
            //if the handbook is active
            if (isActive)
            {
                //set the handbook's position to the active position
                entityLocn = activePos;
                //set each entity that sits in the handbook to its active position
                ((IEntity)resetBtn).setPosition(970, 350);
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    IButton button = symptomButtons[symptom];
                    ((IEntity)button).setPosition(symptomButtonPos[(int)symptom].X, symptomButtonPos[(int)symptom].Y);
                    
                }
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    IButton button = bodyPartButtons[bodyPart];
                    ((IEntity)button).setPosition(bodyPartButtonPos[(int)bodyPart].X, bodyPartButtonPos[(int)bodyPart].Y);
                }
            }
            else
            {
                //set each entity that sits in the handbook to be off screen
                setPosition(1111, 1111);
                ((IEntity)resetBtn).setPosition(1111, 1111);
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    IButton button = symptomButtons[symptom];
                    ((IEntity)button).setPosition(1111,1111);

                }
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    IButton button = bodyPartButtons[bodyPart];
                    ((IEntity)button).setPosition(1111, 1111);
                }
                //resets the entities in the calculator
                ResetCalculator();
            }
        }
        #endregion
        #region Calculator
        /// <summary>
        /// Resets the positions of all the symbols on the calculator
        /// </summary>
        private void ResetCalculator()
        {
            //set all symbols position off screen
            if (symbolSlot1 != null)
            {
                symbolSlot1.SetActive(false);
            }
            if (symbolSlot2 != null)
            {
                symbolSlot2.SetActive(false);
            }
            if (bodyPartSlot != null)
            {
                bodyPartSlot.SetActive(false);
            }
            if (toolSlot != null)
            {
                ((ISymbol)toolSlot).SetActive(false);
            }
        }
        /// <summary>
        /// Updates the position of all the symbols in the calculator, depending on which button is pressed
        /// </summary>
        private void UpdateTheCalculator()
        {
            //Set the tool symbol to the return value of the calculate illness method
            toolSlot = illnessCalculator.CalculateIllness((ISymptomSymbol)symbolSlot1, (ISymptomSymbol)symbolSlot2, (IBodyPartSymbol)bodyPartSlot);
            //sets the symbols postions to be on screen
            if (symbolSlot1 != null && isActive)
            {
                symbolSlot1.SetActive(true);
            }
            if (symbolSlot2 != null && isActive)
            {
                symbolSlot2.SetActive(true);
            }
            if (bodyPartSlot != null && isActive)
            {
                bodyPartSlot.SetActive(true);
            }
            if (toolSlot != null && isActive)
            {
                ((ISymbol)toolSlot).SetActive(true);
            }
            
            //if the handbook is active
            if (isActive)
            {
                //iterate over each symptom in the symptoms enum
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    //Create a temporary button
                    IButton button = symptomButtons[symptom];
                    //if the button is clicked
                    if (button.Clicked)
                    {
                        for (int i = 0; i < symbols.Count; i++)
                        {
                            //return if the symbol has been added to the calculator
                            if (addedToCalc)
                                return;
                            //Create a temporary symbol
                            ISymbol symbol = symbols[i];
                            //if the symbol is a symptom symbol
                            if (symbol.SymbolType is SymbolType.Symptom)
                            {
                                //if the Symptom from the foreach loop is equal to the symbols symptom type
                                if (symptom == ((ISymptomSymbol)symbol).Symptom)
                                {
                                    //if symbol slot 1 is not empty, but symbol slot 2 is empty
                                    if (symbolSlot1 != null && symbolSlot2 == null)
                                    {
                                        //if the Symbol is equal to the same symbol in symbol slot 1
                                        if (((ISymptomSymbol)symbol) == symbolSlot1)
                                        {
                                            //iterate through the symbols list
                                            for (int j = 0; j < symbols.Count; j++)
                                            {
                                                //if the symbol at the current index is a symptom
                                                if (symbols[j].SymbolType is SymbolType.Symptom)
                                                {
                                                    //if the symptom is the same as the symptom type from the symbol
                                                    if (symptom == ((ISymptomSymbol)symbols[j]).Symptom)
                                                    {
                                                        //if the symbol is the same as the symbol slot 1
                                                        if (((ISymptomSymbol)symbols[j]) == symbolSlot1)
                                                        {
                                                            addedToCalc = false;
                                                            //go to the next index in the loop
                                                            j++;
                                                        }
                                                        else
                                                        {
                                                            //add the symbol to the symbol slot 2
                                                            symbolSlot2 = symbols[j];
                                                            //set the added to calc to true
                                                            addedToCalc = true;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        else
                                        {
                                            //set the symbol slot 2 to the symbol
                                            symbolSlot2 = symbol;
                                            //set the added to calc boolean to true
                                            addedToCalc = true;
                                        }
                                    }
                                    //if a symbol hasnt been added 
                                    else if (symbAddedToCalcCount == 0)
                                    {
                                        //set the symbol slot 1 to symbol
                                        symbolSlot1 = symbol;
                                        //set symbol slot 2 to null
                                        symbolSlot2 = null;
                                        //add one to the symbol add counter
                                        symbAddedToCalcCount++;
                                        //set the added to calc boolean to true
                                        addedToCalc = true;
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        //set the added to calc boolean to false
                        addedToCalc = false;
                    }

                }
                //iterate through each body part in the body part enum
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    //create a temporary button set it to the body part button 
                    IButton button = bodyPartButtons[bodyPart];
                    //if the button is clicked
                    if (button.Clicked)
                    {
                        //iterate through each symbol in symbols
                        for (int i = 0; i < symbols.Count; i++)
                        {
                            //if the symbol is added to the calculator return
                            if (addedToCalc)
                                return;
                            //create a temporary ISymbol for the symbol at the current index
                            ISymbol symbol = symbols[i];
                            //if the symbol type of the symbol is a body part
                            if (symbol.SymbolType is SymbolType.BodyPart)
                            {
                                //if the body part is the body part from the for loop
                                if (bodyPart == ((IBodyPartSymbol)symbol).BodyPart)
                                {
                                    //if there is a body part already in the body part slot
                                    if (bodyPartSlot != null)
                                    {
                                        //set the body part to in active
                                        bodyPartSlot.SetActive(false);
                                        //if the tool slot is occupied set the tool symbol to inactive
                                        if (toolSlot != null)
                                            ((ISymbol)toolSlot).SetActive(false);
                                    }
                                    //set the body part symbol to the temp symbol variable
                                    bodyPartSlot = symbol;
                                    //set the body part symbol active
                                    bodyPartSlot.SetActive(true);
                                }
                            }

                        }
                    }
                }
            }
        }
        #endregion
        #region Add the Symbols to the Handbok
        /// <summary>
        /// Adds the symbols from the symbol handler to the symbol list
        /// </summary>
        private void AddSymbolsToList()
        {
            //on the first execution of the this method
            if (!initial)
            {
                initial = true;
                for (int i = 0; i < symbolHandler.Symbols.Count; i++)
                {
                    //cache the symbol from the symbol handler
                    ISymbol symbol = symbolHandler.Symbols[i] as ISymbol;
                    //if the symbol is going to be used in the handbook
                    if (symbol.usedInHandbook)
                    {
                        //add the symbol to the symbols list
                        symbols.Add(symbol);
                    }
                }
            }
        }
        #endregion
        #region Update
        public override void Update()
        {
            //Add the symbols from the symbol handler to the local symbols list
            AddSymbolsToList();
            //if the handbook button is clicked 
            if (handBookBtn.Clicked&&!gotInput)
            {
                gotInput = true;
                //set the active boolean to the opposite value of itself
                isActive = !isActive;
                //reset the postion of all entities in handbook
                ResetPosition();

            }
            //if the handbook button has been released
            if(handBookBtn.Released)
            {
                //reset the gotinput boolean
                gotInput = false;
            }
            //if the reset button has been clicked
            if (resetBtn.Clicked)
            {
                //reset the calculator
                ResetCalculator();
                symbolSlot1 = null;
                symbolSlot2 = null;
                bodyPartSlot = null;
                toolSlot = null;
                symbAddedToCalcCount = 0;
            }
            //update the calculator
            UpdateTheCalculator();
            
        }
        #endregion
    }
}
