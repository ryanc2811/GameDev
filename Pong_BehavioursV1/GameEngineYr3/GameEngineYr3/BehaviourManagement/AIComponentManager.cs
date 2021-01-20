using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.BehaviourManagement
{
    class AIComponentManager : IAIComponentManager
    {
        private IList<IAIComponent> AIComponents;

        public AIComponentManager()
        {
            AIComponents = new List<IAIComponent>();
        }
        public IAIComponent Create<T>() where T : IAIComponent, new()
        {
            IAIComponent AIComponent = new T();
            AIComponents.Add(AIComponent);
            return AIComponent;
        }

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

        public void Update()
        {
            for (int i = 0; i < AIComponents.Count; i++)
            {
                AIComponents[i].Update();
            }
        }
    }
}
