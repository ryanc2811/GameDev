using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using PongEx1.Entities.PatientStuff;

namespace PongEx1.Activity
{
    class QTContainer : Container, IQuickTimeObj,IActivityListener
    {
        Vector2 startPos;
        PatientNum patientNum;
        bool isActive = false;
        public void OnActivityChange(object sender, IEvent args)
        {
            isActive = ((ActivityEvent)args).Active[patientNum];
            if (isActive)
                setPosition(startPos.X, startPos.Y);
            else
                setPosition(1111, 2222);
        }

        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }

        public void SetPatientNum(int patientNum)
        {
            this.patientNum = (PatientNum)patientNum;
        }
    }
}
