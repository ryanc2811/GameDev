using PongEx1.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Entities
{
    interface IPlayer
    {
        void ActivateTool(int patientNum);
        ITool currentTool { get; set; }
        bool Interact { get; }
    }
}
