using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Timer
{
    public interface IGameTimer
    {
        void Update(GameTime gameTime);
        void OnTimerStart(float time);
    }
}
