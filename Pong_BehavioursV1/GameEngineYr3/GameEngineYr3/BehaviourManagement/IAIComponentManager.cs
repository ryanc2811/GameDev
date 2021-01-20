using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    public interface IAIComponentManager
    {
        /// <summary>
        /// Updates AI Components
        /// </summary>
        void Update();
        /// <summary>
        /// Builds an AI Component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IAIComponent Create<T>() where T: IAIComponent, new();

        void RemoveAIComponent(IAIComponent pAIComponent);
    }
}
