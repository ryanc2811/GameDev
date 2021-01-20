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
    /// <summary>
    /// USED TO ENACT EACH AN ACTIVITY TO CURE THE PATIENT
    /// </summary>
    class Tool : ITool,IDeathListener,IGameEndListener
    {
        #region DATA MEMBERS
        //DECLARE AN IDICTIONARY FOR STORING ALL THE ACTIVE BEHAVIOURS
        private IDictionary<PatientNum, bool> activeBehaviours;
        //DECLARE A STRING FOR STORING THE NAME OF THE TOOL
        private string name;
        //DECLARE AN IDICTIONARY FOR STORING THE TOOL BEHAVIOURS
        private IDictionary<PatientNum,IBehaviour> toolBehaviours;
        #endregion
        #region CONSTRUCTOR
        public Tool(string name)
        {
            //STORES THE NAME LOCALLY
            this.name = name;
            //INSTANTIATE THE DICTIONARIES
            toolBehaviours = new Dictionary<PatientNum, IBehaviour>();
            activeBehaviours = new Dictionary<PatientNum, bool>();
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                activeBehaviours.Add(num, false);
            }
        }
        #endregion
        #region PROPERTIES
        /// <summary>
        /// GETTER FOR THE NAME OF THE TOOL
        /// </summary>
        public string GetName { get { return name; } }
        /// <summary>
        /// SETTER FOR THE BEHAVIOUR OF THE TOOL
        /// </summary>
        /// <param name="behaviour"></param>
        /// <param name="patientNum"></param>
        public void ReceiveJob(IBehaviour behaviour, int patientNum)
        {
            toolBehaviours[(PatientNum)patientNum] = behaviour;
            ((IToolBehaviour)behaviour).SetPatientNum(patientNum);
        }
        #endregion
        #region SET BEHAVIOUR ACTIVE
        /// <summary>
        /// SETS THE TOOL ACTIVE
        /// </summary>
        /// <param name="active"></param>
        /// <param name="patientNum"></param>
        public void SetActive(bool active,int patientNum)
        {
            activeBehaviours[(PatientNum)patientNum] = active;
        }
        #endregion
        #region UPDATE
        /// <summary>
        /// UPDATES THE TOOL
        /// </summary>
        public void Update()
        {
            
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //IF THE TOOL IS ACTIVE, ENACT THE BEHAVIOUR
                if (toolBehaviours[num] != null && activeBehaviours[num]==true)
                    toolBehaviours[num].Behaviour();
                //IF THE TOOL HAS ENDED, STOP THE BEHAVIOUR
                if (toolBehaviours[num] != null && ((IToolBehaviour)toolBehaviours[num]).HasEnded)
                {
                    activeBehaviours[num] = false;
                }           
            }
        }
        #endregion
        #region EVENT LISTENERS
        /// <summary>
        /// LISTENS FOR THE DEATH EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnDeath(object sender, IEvent args)
        {  
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //IF THE PATIENT IS DEAD SET THE BEHAVIOUR ASSOCIATED WITH THAT PATIENT INACTIVE 
                if (((DeathEvent)args).Dead[num])
                    activeBehaviours[num] = false;
            }
        }
        /// <summary>
        /// LISTENS FOR THE GAME END EVENT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnGameEnd(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                //IF THE GAME ENDS SET THE BEHAVIOUR ASSOCIATED WITH THAT PATIENT INACTIVE 
                activeBehaviours[num] = false;
                Console.WriteLine("GAD");
            }
        }
        #endregion
    }
}
