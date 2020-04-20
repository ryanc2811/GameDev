using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Class for Handling the Game UI elements
    /// </summary>
    class GameUI :IActivityListener,IGameUI
    {
        //DECLARE an IList of type IEntity for storing the UIElements
        private IList<IEntity> UIElements;
        //DECLARE an IGameTimer for handling the Timer event
        private IGameTimer gameTimer;
        //DECLARE a bool for checking if the game timer has started
        private bool gameTimerStarted = false;
        public GameUI()
        {
            //INSTANTIATE UI elements list
            UIElements = new List<IEntity>();
        }
        /// <summary>
        /// Adds the Game Timer handler and sets it locally
        /// </summary>
        /// <param name="gameTimer"></param>
        public void AddGameTimer(IGameTimer gameTimer)
        {
            this.gameTimer = gameTimer;
        }
        /// <summary>
        /// Adds the UI Entity to UI elements list
        /// </summary>
        /// <param name="entity"></param>
        public void AddUIElement(IEntity entity)
        {
            UIElements.Add(entity);
        }
        /// <summary>
        /// Method that triggers when the activity event is triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnActivityEnd(object sender, IEvent args)
        {
            //Iterate over each patient in the PatientNum Enum
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //if the Activity has ended 
                if (((ActivityEvent)args).Ended[num])
                {
                    foreach(IEntity entity in UIElements)
                    {
                        //Update the Score
                        if (entity is IScore)
                            ((IScore)entity).UpdateScore();
                    }
                }
            }
        }
        /// <summary>
        /// Updates each frame
        /// </summary>
        public void Update()
        {
            //if the timer has not started
            if (!gameTimerStarted)
            {
                gameTimerStarted = true;
                //Start the Game timer with a duration of 60 seconds
                gameTimer.OnTimerStart(60f);
            }
                
        }
    }
}
