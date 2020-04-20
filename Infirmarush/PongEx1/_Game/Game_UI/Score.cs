using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    /// <summary>
    /// Text entity for Score
    /// </summary>
    class Score:TextEntity,IScore
    {
        //DECLARE an int for storing the total score
        private int score;
        public Score()
        {
            //Set default text to "0"
            text = "0";
            //Set the Colour of the text to white
            colour = Color.White;
        }
        public void UpdateScore()
        {
            //Add 1 to the score
            score++;
            //update the text with the score variable
            text = score.ToString();
        }
    }
}
