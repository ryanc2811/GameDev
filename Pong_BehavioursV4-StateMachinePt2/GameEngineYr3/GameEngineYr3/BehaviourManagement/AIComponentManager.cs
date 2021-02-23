using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    class AIComponentManager : IAIComponentManager
    {
        //DECLARE an IList for storing references to each AIComponent
        private IList<IAIComponent> AIComponents;

        public AIComponentManager()
        {
            AIComponents = new List<IAIComponent>();
        }
        /// <summary>
        /// Factory method for creating an AIComponent
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IAIComponent Create<T>() where T : IAIComponent, new()
        {
            IAIComponent AIComponent = new T();
            AIComponents.Add(AIComponent);
            return AIComponent;
        }
        /// <summary>
        /// Triggers the OnConentLoad method on each AIComponent
        /// </summary>
        public void OnContentLoad()
        {
            foreach (IAIComponent aIComponent in AIComponents)
                aIComponent.OnContentLoad();
        }
        /// <summary>
        /// Removes an AI Component
        /// </summary>
        /// <param name="pAIComponent"></param>
        public void RemoveAIComponent(IAIComponent pAIComponent)
        {
            for (int i = 0; i < AIComponents.Count; i++)
            {
                if (AIComponents[i] == pAIComponent)
                {
                    AIComponents.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Updates the AIComponents
        /// </summary>
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < AIComponents.Count; i++)
            {
                AIComponents[i].Update(gameTime);
            }
        }
    }
}
