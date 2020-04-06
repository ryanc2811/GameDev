using Microsoft.Xna.Framework;
using PongEx1._Game.Events;
using PongEx1.Entities;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongEx1.Activity
{
    class QTGreen : GameXEntity, IShape,ICollidable,IQuickTimeObj,IActivityListener
    {
        Vector2 startPos;
        bool isActive = false;
        PatientNum patientNum;
        public int getWidth()
        {
            return texture.Width;
        }
        public int getHeight()
        {
            return texture.Height;
        }

        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            
        }

        public void SetActivePosition(Vector2 position)
        {
            startPos = position;
        }

        public void OnActivityChange(object sender, IEvent args)
        {
            isActive=((ActivityEvent)args).Active[patientNum];
            if (isActive)
                setPosition(startPos.X, startPos.Y);
            else
                setPosition(1111, 2222);
        }

        public void SetPatientNum(int patientNum)
        {
            this.patientNum = (PatientNum)patientNum;
        }
    }
}
