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
    class HandBook:GameXEntity,IHandBook
    {
        private IList<ISymbol> symbols;
        private ISymbolHandler symbolHandler;
        private IIllnessCalculator illnessCalculator;
        private IDictionary<Symptom, IButton> symptomButtons;
        private IDictionary<BodyPart, IButton> bodyPartButtons;
        private IEntity toolSlot;
        private IButton handBookBtn;
        private IButton resetBtn;
        private ISymbol symbolSlot1;
        private ISymbol symbolSlot2;
        private ISymbol bodyPartSlot;
        private int symptomButtonCounter=-1;
        private int bodyPartButtonCounter=-1;
        private int symbAddedToCalcCount = 0;
        private bool addedToCalc=false;
        private bool isActive = false;
        private bool gotInput = false;
        
        private Vector2[] symptomButtonPos = { new Vector2(375, 275), new Vector2(375, 375) };
        private Vector2[] bodyPartButtonPos = { new Vector2(900, 550), new Vector2(1000, 550), new Vector2(1100, 550) };
        private Vector2 activePos=new Vector2(325, 100);
        bool initial = false;
        public HandBook()
        {
            layerDepth = 0.1f;
            symbols = new List<ISymbol>();
            symptomButtons = new Dictionary<Symptom,IButton>();
            bodyPartButtons = new Dictionary<BodyPart,IButton>();

        }
        public void AddResetButton(IButton resetButton)
        {
            resetBtn = resetButton;
        }
        public void AddHandBookButton(IButton handBookButton)
        {
            handBookBtn = handBookButton;
        }
        public void AddSymbolButton(SymbolType symbolType,IButton symbolButton)
        {
            if(symbolType is SymbolType.BodyPart)
            {
                bodyPartButtonCounter++;
                bodyPartButtons[(BodyPart)bodyPartButtonCounter] = symbolButton;
            }
            else if (symbolType is SymbolType.Symptom)
            {
                symptomButtonCounter++;
                symptomButtons[(Symptom)symptomButtonCounter] = symbolButton;
            }
        }
        public void AddSymbolHandler(ISymbolHandler symbolHandler)
        {
            this.symbolHandler = symbolHandler;
        }
        public void AddIllnessCalculator(IIllnessCalculator illnessCalculator)
        {
            this.illnessCalculator = illnessCalculator;
        }
        private void ResetPosition()
        {
            if (isActive)
            {
                entityLocn = activePos;
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
                ResetCalculator();
            }
        }
        private void ResetCalculator()
        {
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
        public override void Update()
        {
            if (handBookBtn.Clicked&&!gotInput)
            {
                gotInput = true;
                isActive = !isActive;
                ResetPosition();

            }
            if(handBookBtn.Released)
            {
                gotInput = false;
            }
            if (resetBtn.Clicked)
            {
                ResetCalculator();
                symbolSlot1 = null;
                symbolSlot2 = null;
                bodyPartSlot = null;
                toolSlot = null;
                symbAddedToCalcCount = 0;
            }
            
            toolSlot = illnessCalculator.CalculateIllness((ISymptomSymbol)symbolSlot1, (ISymptomSymbol)symbolSlot2, (IBodyPartSymbol)bodyPartSlot);
            if (symbolSlot1 != null&&isActive)
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
            if (!initial)
            {
                initial = true;
                for (int i = 0; i < symbolHandler.Symbols.Count; i++)
                {
                    ISymbol symbol = symbolHandler.Symbols[i] as ISymbol;
                    if (symbol.usedInHandbook)
                    {
                        symbols.Add(symbol);
                    } 
                }
            }
            if (isActive)
            {
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    IButton button = symptomButtons[symptom];
                    if (button.Clicked)
                    {
                        for (int i = 0; i < symbols.Count; i++)
                        {
                            if (addedToCalc)
                                return;

                            ISymbol symbol = symbols[i];
                            if (symbol.SymbolType is SymbolType.Symptom)
                            {
                                if (symptom == ((ISymptomSymbol)symbol).Symptom)
                                {
                                    if (symbolSlot1 != null && symbolSlot2 == null)
                                    {

                                        if (((ISymptomSymbol)symbol) == symbolSlot1)
                                        {
                                            for (int j = 0; j < symbols.Count; j++)
                                            {

                                                if (symbols[j].SymbolType is SymbolType.Symptom)
                                                {
                                                    if (symptom == ((ISymptomSymbol)symbols[j]).Symptom)
                                                    {
                                                        if (((ISymptomSymbol)symbols[j]) == symbolSlot1)
                                                        {
                                                            addedToCalc = false;
                                                            j++;
                                                        }
                                                        else
                                                        {
                                                            symbolSlot2 = symbols[j];
                                                            addedToCalc = true;
                                                        }
                                                    }
                                                }

                                            }
                                        }
                                        else
                                        {
                                            symbolSlot2 = symbol;
                                            addedToCalc = true;
                                        }
                                    }
                                    else if (symbAddedToCalcCount == 0)
                                    {
                                        symbolSlot1 = symbol;

                                        symbolSlot2 = null;
                                        symbAddedToCalcCount++;
                                        addedToCalc = true;
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        addedToCalc = false;
                    }

                }
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    IButton button = bodyPartButtons[bodyPart];
                    if (button.Clicked)
                    {
                        for (int i = 0; i < symbols.Count; i++)
                        {
                            if (addedToCalc)
                                return;
                            ISymbol symbol = symbols[i];
                            if (symbol.SymbolType is SymbolType.BodyPart)
                            {
                                if (bodyPart == ((IBodyPartSymbol)symbol).BodyPart)
                                {
                                    if (bodyPartSlot != null)
                                    {
                                        bodyPartSlot.SetActive(false);
                                        if (toolSlot != null)
                                            ((ISymbol)toolSlot).SetActive(false);
                                    }
                                        
                                        
                                    bodyPartSlot = symbol;
                                    bodyPartSlot.SetActive(true);
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
