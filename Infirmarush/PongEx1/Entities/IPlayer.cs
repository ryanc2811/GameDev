using PongEx1.Entities.Interacted;
using PongEx1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities
{
    /// <summary>
    /// INTERFACE FOR THE PLAYER
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// ACTIVATE THE PLAYERS CURRENT TOOL
        /// </summary>
        /// <param name="patientNum"></param>
        void ActivateTool(int patientNum);
        /// <summary>
        /// GETS AND SETS THE PLAYERS CURRENT TOOL
        /// </summary>
        ITool currentTool { get; set; }
        /// <summary>
        /// GETS THE INTERACT STATE OF THE PLAYER
        /// </summary>
        bool Interact { get; }
        /// <summary>
        /// ADDS THE INTERACT HANDLER TO THE PLAYER
        /// </summary>
        /// <param name="interact"></param>
        void AddInteractHandler(IInteractHandler interact);
    }
}
