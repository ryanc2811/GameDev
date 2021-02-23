using Microsoft.Xna.Framework;
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
        void Update(GameTime gameTime);
        /// <summary>
        /// Builds an AI Component
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IAIComponent Create<T>() where T: IAIComponent, new();
        /// <summary>
        /// Runs the OnContentLoad method on each AIComponent
        /// </summary>
        void OnContentLoad();
        /// <summary>
        /// Removes an AI Component
        /// </summary>
        /// <param name="pAIComponent"></param>
        void RemoveAIComponent(IAIComponent pAIComponent);
    }
}
