using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    abstract class AIComponent:IAIComponent
    {
        public abstract void SetAIUser(IAIUser aiUser);

        public abstract void Initialise();

        public abstract void Update();
        public abstract Vector2 GetPosition();

        public abstract int Height();

        public abstract int Width();
    }
}
