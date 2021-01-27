using GameEngine.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    public interface IAIComponent
    {
        void SetAIUser(IAIUser aiUser);

        void Update();

        Vector2 GetPosition();
        int Height();
        int Width();

        void Initialise();
    }
}
