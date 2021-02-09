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
        /// <summary>
        /// Sets the AI User for the Ai component
        /// </summary>
        /// <param name="aiUser"></param>
        public abstract void SetAIUser(IAIUser aiUser);
        /// <summary>
        /// Initialses the AI Component
        /// </summary>
        public abstract void Initialise();
        /// <summary>
        /// Updates the AI Component
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// Gets the postion of the AI User
        /// </summary>
        /// <returns></returns>
        public abstract Vector2 GetPosition();
        /// <summary>
        /// Runs after content is loaded
        /// </summary>
        public abstract void OnContentLoad();
        /// <summary>
        /// returns the height of the texture
        /// </summary>
        /// <returns></returns>
        public abstract int Height();
        /// <summary>
        /// returns the width of the texture
        /// </summary>
        /// <returns></returns>
        public abstract int Width();

        public abstract IAIUser GetAIUser();
    }
}
