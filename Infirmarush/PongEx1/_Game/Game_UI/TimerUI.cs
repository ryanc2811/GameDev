using Microsoft.Xna.Framework.Graphics;
using PongEx1._Game.Events;
using PongEx1._Game.GameEnd;
using PongEx1._Game.Timer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Class for Displaying the Timer
    /// </summary>
    class TimerUI : TextEntity, ITimerListener,ITimerEntity
    {
        //DECLARE a bool for checking if the Timer has ended
        private bool hasEnded=false;
        //DECLARE a float for the timer
        private float timer=3600f;
        //DECLARE an IGameEndHandler for handling the GameEnd Event
        private IGameEndHandler _gameEndHandler;
        /// <summary>
        /// Adds the IGameHandler to the TimerUI
        /// </summary>
        /// <param name="gameEndHandler"></param>
        public void AddGameEndHandler(IGameEndHandler gameEndHandler)
        {
            _gameEndHandler = gameEndHandler;
        }
        /// <summary>
        /// Method that Triggers when the Timer event starts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTimerStart(object sender, IEvent args)
        {
            //if the timer has ended
            if (((TimerEvent)args).TimerEnd)
            {
                hasEnded = true;
                //handle the Game end event
                _gameEndHandler.OnGameEnd(true);
            }                
        }

        public override void Update()
        {
            //if the Timer has not ended
            if (!hasEnded)
            {
                //count down
                timer--;
                float convertedTimer = timer / 60f;
                //Set the text to the converted timer and use the format "00"
                text = convertedTimer.ToString("00");
            }
        }
    }
}
