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
    /// <summary>
    /// BEHAVIOUR OF THE BONESAW TOOL- QUICK TIME ACTIVITY
    /// </summary>
    class BoneSawBehaviour:ToolBehaviour,IInputListener,IDeathListener
    {
        #region DATA MEMBERS
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
        #endregion
        #region QUICK TIME OBJECTS
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
        /// <summary>
        /// SETS ALL THE QUICK TIME OBJECT ACTIVE
        /// </summary>
        /// <param name="active"></param>
        private void SetQTItemActive(bool active)
        {
            ((IQuickTimeObj)QTContainer).SetActive(active);
            ((IQuickTimeObj)QTLine).SetActive(active);
            ((IQuickTimeObj)QTGreen).SetActive(active);
            
        }
        /// <summary>
        /// SET THE GREEN AREA'S POSITION TO A RANDOM POSITION WITH IN THE BOUNDS OF THE CONTAINER
        /// </summary>
        private void SetRandomGreenPos()
        {
            //INSTANTIATE A NEW RANDOM
            Random random = new Random();
            //SET THE MAX X POSITION THE GREEN AREA CAN GO TO
            float maxX = QTContainer.getPosition().X + ((IShape)QTContainer).getWidth() - ((IShape)QTGreen).getWidth();
            //SET THE MINIMUM X THAT THE GREEN AREA CAN GO TO
            float x = random.Next((int)QTContainer.getPosition().X, (int)maxX);
            //SET THE GREEN AREAS POSITION TO THIS POSITION
            QTGreen.setPosition(x, QTGreen.getPosition().Y);
        }
        /// <summary>
        /// Checks to see if the quick time line is in the green area when e is pressed
        /// </summary>
        private void hitGreenCheck()
        {
            interact = true;
            //IF THE LINE IS IN THE GREEN AREA
            if (inGreen)
            {
                if (!hitGreen)
                {
                    hitGreen = true;
                    //IF THE TIMES THAT THE LINE HAS HIT THE GREEN AREA WHILE THE INTERACT KEY IS PRESSED, IS LESS THAN 3
                    if (quickTimeCount < 3)
                    {
                        //RANDOMLY SET THE GREEN AREAS POSITION
                        SetRandomGreenPos();
                        Console.WriteLine("ding");
                        //add one to the counter
                        quickTimeCount += 1;
                    }
                }
            }
            else
            {
                //IF THE  THE LINE HAS NOT HIT THE GREEN AREA WHILE THE INTERACT KEY IS PRESSED, PATIENT TAKES DAMAGE
                Console.WriteLine("OW");
                _damageHandler.OnTakeDamage(0.25, (PatientNum)patientNum);
            }
        }
        #endregion
        #region BEHAVIOUR
        /// <summary>
        /// RUNS THE BEHAVIOUR OF THE BONESAW TOOL
        /// </summary>
        public override void Behaviour()
        {
            //IF THE BEHAVIOUR HAS RESET
            if (hasEnded)
            {
                //SET THE BEHAVIOUR ACTIVE
                isActive = true;
            }
            //IF THE BEHAVIOUR IS ACTIVE AND IT IS THE FIRST FRAME OF THE BEHAVIOUR
            if (isActive && !initial)
            {
                initial = true;
                hasEnded = false;
                //REST THE TIMES THAT THE QUICK TIME HAS BEEN CORRECT
                quickTimeCount = 0;
                //SET THE QUICK TIMER OBJECT ACTIVE
                SetQTItemActive(true);
                //SEND THE DATA TO ACTIVITY HANDLER
                _activityHandler.OnActivityEnd(false, (PatientNum)patientNum);
            }
            //IF THE QUICK TIME ACTIVITY HAS ENDED
            if (quickTimeCount >= 3)
            {
                if (activityChanged)
                {
                    activityChanged = false;
                    isActive = false;
                    initial = false;
                    hasEnded = true;
                    //SEND DATE TO ACTIVITY HANDLER
                    _activityHandler.OnActivityEnd(true, (PatientNum)patientNum);
                    //SET THE QUICK TIME OBJECT TO INACTIVE
                    SetQTItemActive(false);
                    Console.WriteLine("Patient is cured");
                }
            }
            else
            {
                if (!activityChanged)
                {
                    //RESET THE QUICK TIME COUNTER
                    quickTimeCount = 0;
                    //SET THE ACTIVITY TO ACTIVE
                    isActive = true;
                    activityChanged = true;
                    hasEnded = false;
                    //SET THE QUICK TIME OBJECT TO ACTIVE
                    SetQTItemActive(true);
                }
            }
            //IF THE QUICK TIME LINE HAS HIT THE GREEN OBJECT
            if (((IQTLine)QTLine).gethasHitGreen)
            {
                //QUICK TIME LINE IS IN GREEN AREA
                inGreen = true;
            }
            else
            {
                //QUICK TIME LINE IS NOT IN GREEN AREA
                inGreen = false;
            }
            //IF THE QUICK TIME INTERACT KEY IS UP
            if (Keyboard.GetState().IsKeyUp(Keys.E))
            {
                //RESET INTERACT BOOLEANS
                interact = false;
                gotInput = false;
                hitGreen = false;
            }
            
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR NEW INPUT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnNewInput(object sender, InputEventArgs args)
        {
            //IF THE E KEY HAS BEEN PRESSED
            if (args.PressedKeys.Contains(Keys.E)&&!gotInput&&isActive)
            {
                gotInput = true;
                if (!interact&&!hitGreen)
                {
                    //CHECK IF THE LINE HAS HIT THE GREEN AREA
                    hitGreenCheck();
                }
            }
            
        }
        /// <summary>
        /// LISTENS FOR THE DEATH EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnDeath(object sender, IEvent args)
        {
            //IF THE PATIENT IS DEAD
            if (((DeathEvent)args).Dead[(PatientNum)patientNum])
            {
                Console.WriteLine((PatientNum)patientNum);
                //SET THE QUICK TIME OBJECT TO INACTIVE
                SetQTItemActive(false);
                hasEnded = true;
                initial = false;
            }
        }
        /// <summary>
        /// LISTENS FOR THE GAME ENDING
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public override void OnGameEnd(object sender, IEvent args)
        {
            hasEnded = true;
            initial = false;
            //SETS THE QUICK TIME OBJECT TO INACTIVE
            SetQTItemActive(false);
        }
    }
    #endregion
}
