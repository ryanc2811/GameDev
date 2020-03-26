using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class Tool : ITool
    {
        private bool isActive = false;
        private string name;
        IToolBehaviour<ToolBehaviour> toolBehaviour;

        public Tool(string name)
        {
            this.name = name;
        }
        
        public string GetName { get { return name; } }

        public void setActive(bool active)
        {
            isActive = active;
        }
        public void receiveJob(IToolBehaviour<ToolBehaviour> behaviour)
        {
            toolBehaviour = behaviour;
        }

        public void Update()
        {
            
            if(toolBehaviour!=null)
                toolBehaviour.Behaviour();
        }

       
    }
}
