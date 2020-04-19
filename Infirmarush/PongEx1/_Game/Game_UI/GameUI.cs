using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1._Game.Game_UI
{
    class GameUI :IActivityListener,IGameUI
    {
        private IList<IEntity> UIElements;
        private IGameTimer gameTimer;
        bool initial = false;
        public GameUI()
        {
            UIElements = new List<IEntity>();
        }

        public void AddGameTimer(IGameTimer gameTimer)
        {
            this.gameTimer = gameTimer;
        }

        public void AddUIElement(IEntity entity)
        {
            UIElements.Add(entity);
        }
        public void OnActivityEnd(object sender, IEvent args)
        {
            foreach (PatientNum num in Enum.GetValues(typeof(PatientNum)))
            {
                if (((ActivityEvent)args).Ended[num])
                {
                    foreach(IEntity entity in UIElements)
                    {
                        if (entity is IScore)
                            ((IScore)entity).UpdateScore();
                    }
                }
            }
        }

        public void Update()
        {
            if (!initial)
            {
                initial = true;
                gameTimer.OnTimerStart(60f);
            }
                
        }
    }
}
