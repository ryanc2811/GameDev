using PongEx1._Game.Behaviour;
using PongEx1._Game.Events;
using PongEx1._Game.GameEnd;
using PongEx1.Activity;
using PongEx1.Entities.PatientStuff;
using PongEx1.Tools.Tool_Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Tools
{
    class Tool : ITool,IDeathListener,IGameEndListener
    {
        
        private IDictionary<PatientNum, bool> activeBehaviours;
        private string name;
        private IDictionary<PatientNum,IBehaviour> toolBehaviours;

        public Tool(string name)
        {
            this.name = name;
            toolBehaviours = new Dictionary<PatientNum, IBehaviour>();
            activeBehaviours = new Dictionary<PatientNum, bool>();
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                activeBehaviours.Add(num, false);
            }
        }
        
        public string GetName { get { return name; } }

        public void setActive(bool active,int patientNum)
        {
            activeBehaviours[(PatientNum)patientNum] = active;
        }
        public void receiveJob(IBehaviour behaviour,int patientNum)
        {
            toolBehaviours[(PatientNum)patientNum]=behaviour;
            ((IToolBehaviour)behaviour).SetPatientNum(patientNum);
        }

        public void Update()
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (toolBehaviours[num] != null && activeBehaviours[num]==true)
                    toolBehaviours[num].Behaviour();
                if (toolBehaviours[num] != null && ((IToolBehaviour)toolBehaviours[num]).HasEnded)
                {
                    activeBehaviours[num] = false;
                }           
            }
        }

        public void OnDeath(object sender, IEvent args)
        {  
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (((DeathEvent)args).Dead[num])
                    activeBehaviours[num] = false;
            }
        }

        public void OnGameEnd(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                activeBehaviours[num] = false;
            }
        }
    }
}
