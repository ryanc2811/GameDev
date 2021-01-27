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
        /// <summary>
        /// Sets the AI User of the AIComponent
        /// </summary>
        /// <param name="aiUser"></param>
        void SetAIUser(IAIUser aiUser);
        /// <summary>
        /// Updates the AI Component
        /// </summary>
        void Update();
        /// <summary>
        /// Runs after Content is loaded
        /// </summary>
        void OnContentLoad();
        /// <summary>
        /// returns the position of Entity
        /// </summary>
        /// <returns></returns>
        Vector2 GetPosition();
        /// <summary>
        /// returns the height of the texture
        /// </summary>
        /// <returns></returns>
        int Height();
        /// <summary>
        /// returns the width of the texture
        /// </summary>
        /// <returns></returns>
        int Width();
        /// <summary>
        /// Initialises the AIComponent
        /// </summary>
        void Initialise();
    }
}
