using GameEngine.Input;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.State_Conditions
{
    class RestartBall : BaseCondition, IInputListener
    {
        bool ballServed = false;
        public override bool FindOutcome()
        {
            return ballServed;
        }

        public void OnNewInput(object sender, InputEventArgs args)
        {
            if (args.PressedKeys.Contains(Keys.R))
            {
                ballServed = true;
            }
        }

        public override void ExitCondition()
        {
            ballServed = false;
        }
    }
}
