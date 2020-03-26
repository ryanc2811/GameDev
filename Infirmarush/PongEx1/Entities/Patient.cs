using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Illness;

namespace PongEx1.Entities
{
    class Patient : GameXEntity,ICollidable
    {
        //DECLARE an IIllnessFactory for creating new illnesses, call it illnessFactory
        IIllnessFactory illnessFactory;
        //DECLARE a reference for IIllness
        IIllness illness;
        //DECLARE an IList for storing the symptoms from illness locally, call it symptoms
        IList<Symptom> symptoms;
        //DECLARE a reference to BodyPart
        BodyPart bodyPart;
        //TEST BOOL FOR COLLIDING
        bool hasCollided = false;
        public Patient()
        {
            //INSTANTIATE a new illness factory
            illnessFactory = new IllnessFactory();
            //create a new illness using the factory
            illness = illnessFactory.create();
            //add the symptoms content to the local symptoms list
            symptoms = illness.getSymptoms;
            //add the the body part from illness and set local body part to it
            bodyPart = illness.getBodyPart;
            
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            if (!hasCollided)
            {
                hasCollided = true;
                Console.WriteLine(bodyPart);
                for (int i = 0; i < symptoms.Count; i++)
                {
                    Console.WriteLine(symptoms[i]);
                    if (((Player)entity).currentTool != null)
                    {
                        if (symptoms[i] == Symptom.infection && ((Player)entity).currentTool.GetName == "BoneSaw")
                        {
                            //((Player)entity).ActivateTool();
                        }

                        else
                        {
                            Console.WriteLine("Wrong Tool, Sorry");
                        }

                    }

                }
            }
            
        }
        public override void Update()
        {
            
            

        }
    }
}
