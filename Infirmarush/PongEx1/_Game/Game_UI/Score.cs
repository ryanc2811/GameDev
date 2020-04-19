using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    class Score:TextEntity,IScore
    {
        private int score;
        public Score()
        {
            text = "0";
            colour = Color.White;
        }
        public void UpdateScore()
        {
            score++;
            text = score.ToString();
        }
    }
}
