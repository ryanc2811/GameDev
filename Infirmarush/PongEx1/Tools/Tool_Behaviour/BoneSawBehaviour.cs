using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using System;
using PongEx1._Game.Behaviour;
using PongEx1._Game.Events;

namespace PongEx1.Tools.Tool_Behaviour
{
    class BoneSawBehaviour:ToolBehaviour,IInputListener,IDeathListener
    {
        //IEntity objects for the quick time activity
        private IEntity QTContainer;
        private IEntity QTLine;
        private IEntity QTGreen;
        
        //boolean for checking if the player has pressed e when the line is in the green area
        bool hitGreen = false;
        //boolean for checking if the line is in the green area
        bool inGreen = false;
        //boolean to switch the hasHitGreen method on and off
        bool interact = false;
        //boolean for initialising position of the quick time objects
        
        //boolean for checking if input has been taken
        bool gotInput = false;
        //boolean for turning the activity off
        bool activityChanged = false;
        //integer for counting the number of times that the player has hit the green area with the line
        int quickTimeCount = 0;
        /// <summary>
        /// Setter for the quick time objects
        /// </summary>
        /// <param name="QTContainer"></param>
        /// <param name="QTLine"></param>
        /// <param name="QTGreen"></param>
        public void SetQTItems(IEntity QTContainer, IEntity QTLine, IEntity QTGreen)
        {
            this.QTContainer= QTContainer;
            this.QTLine=QTLine;
            this.QTGreen= QTGreen;
        }
        private void SetQTItemActive(bool active)
        {
            ((IQuickTimeObj)QTContainer).SetActive(active);
            ((IQuickTimeObj)QTLine).SetActive(active);
            ((IQuickTimeObj)QTGreen).SetActive(active);
            
        }
        public override void Behaviour()
        {
            if (hasEnded)
            {
                isActive = true;
            }
            if (isActive && !initial)
            {
                initial = true;
                hasEnded = false;
                quickTimeCount = 0;
                SetQTItemActive(true);
                _activityHandler.OnActivityEnd(false, (PatientNum)patientNum);
            }
            if (quickTimeCount >= 3)
            {
                if (activityChanged)
                {
                    activityChanged = false;
                    isActive = false;
                    initial = false;
                    hasEnded = true;
                    _activityHandler.OnActivityEnd(true, (PatientNum)patientNum);
                    SetQTItemActive(false);
                    Console.WriteLine("Patient is cured");
                }
            }
            else
            {
                if (!activityChanged)
                {
                    quickTimeCount = 0;
                    isActive = true;
                    activityChanged = true;
                    hasEnded = false;
                    SetQTItemActive(true);
                }
            }
            if (((IQTLine)QTLine).gethasHitGreen)
            {
                inGreen = true;
            }
            else
            {
                inGreen = false;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                interact = false;
                gotInput = false;
                hitGreen = false;
            }
            
        }
        private void SetRandomGreenPos()
        {
            Random random = new Random();
            float maxX = QTContainer.getPosition().X +((IShape)QTContainer).getWidth()-((IShape)QTGreen).getWidth();
            float x = random.Next((int)QTContainer.getPosition().X,(int)maxX);
            QTGreen.setPosition(x, QTGreen.getPosition().Y);
        }
       /// <summary>
       /// Checks to see if the quick time line is in the green area when e is pressed
       /// </summary>
        private void hitGreenCheck()
        {
            interact = true;
            if (inGreen)
            {
                if (!hitGreen)
                {
                    hitGreen = true;
                    if (quickTimeCount < 3)
                    {
                        SetRandomGreenPos();
                        Console.WriteLine("ding");
                        //add one to the counter
                        quickTimeCount += 1;
                    }
                }
            }
            else
            {
                Console.WriteLine("OW");
                _damageHandler.OnTakeDamage(0.25,(PatientNum)patientNum);
            }
        }
        public void OnNewInput(object sender, InputEventArgs args)
        {
            if (args.PressedKeys.Contains(Keys.E)&&!gotInput&&isActive)
            {
                gotInput = true;
                if (!interact&&!hitGreen)
                {
                    hitGreenCheck();
                }
            }
            
        }
        public override void OnDeath(object sender, IEvent args)
        {
            
            if (((DeathEvent)args).Dead[(PatientNum)patientNum])
            {
                Console.WriteLine((PatientNum)patientNum);
                SetQTItemActive(false);
                hasEnded = true;
                initial = false;
            }
        }
        public override void OnGameEnd(object sender, IEvent args)
        {
            hasEnded = true;
            initial = false;
            SetQTItemActive(false);
            
        }
    }
}
