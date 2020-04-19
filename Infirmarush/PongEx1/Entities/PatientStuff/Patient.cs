using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities._Symbols;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Healing;
using PongEx1.Entities.PatientStuff.Health_Bar;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Illness;

namespace PongEx1.Entities.PatientStuff
{
    class Patient : GameXEntity,ICollidable,IDamageListener,IImmovable,IActivityListener,ITimerListener,IHealListener
    {
        PatientNum patientNum;
        IDeathHandler death;
        //DECLARE an IIllnessFactory for creating new illnesses, call it illnessFactory
        IIllnessFactory illnessFactory;
        //DECLARE a reference for IIllness
        IIllness illness;
        //DECLARE an IList for storing the symptoms from illness locally, call it symptoms
        IList<Symptom> symptoms;
        //DECLARE a reference to BodyPart
        BodyPart bodyPart;
        IHealthBar healthBar;
        ISymbolManager symbolManager;
        double health;
        double maxHealth = 1.0;
        bool isDead = false;
        bool activityEnded = false;
        Vector2 startPosition;
        //DECLARE BOOL FOR COLLIDING
        bool hasCollided = false;
        bool initial = false;
        public Patient()
        {
            //INSTANTIATE a new illness factory
            illnessFactory = new IllnessFactory();
            //Generate a new illness for the patient
            CreateNewIllness();
            //set health to max health
            health = maxHealth;
            
        }
        public void AddSymbolManager(ISymbolManager pSymbolManager)
        {
            symbolManager = pSymbolManager;
        }
        public PatientNum GetPatientNum
        {
            get { return patientNum; }
        }
        public void SetHealthBar(IHealthBar healthBar)
        {
            this.healthBar = healthBar;
        }
        public void SetPatientNum(PatientNum patientNum)
        {
            this.patientNum = patientNum;
            
        }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X+25, (int)entityLocn.Y+25, texture.Width, texture.Height);
        }
        public void AddDeathHandler(IDeathHandler deathHandler)
        {
            death = deathHandler;
        }
        private void CreateNewIllness()
        {
            //create a new illness using the factory
            illness = illnessFactory.create();
            //add the symptoms content to the local symptoms list
            symptoms = illness.getSymptoms;
            //add the the body part from illness and set local body part to it
            bodyPart = illness.getBodyPart;
            Console.WriteLine(bodyPart);
        }
        public void onCollide(IEntity entity)
        {
            if (entity is IPlayer) { 
            if (!hasCollided && ((IPlayer)entity).Interact)
            {
                hasCollided = true;
                Console.WriteLine(bodyPart);
                for (int i = 0; i < symptoms.Count; i++)
                {
                    Console.WriteLine(symptoms[i]);
                    if (((IPlayer)entity).currentTool != null)
                    {
                            if (symptoms[i] == Symptom.infection && ((IPlayer)entity).currentTool.GetName == "BoneSaw")
                            {
                                ((IPlayer)entity).ActivateTool((int)patientNum);
                            }
                            else if (symptoms[i] == Symptom.nausea && ((IPlayer)entity).currentTool.GetName == "Leech")
                            {
                                ((IPlayer)entity).ActivateTool((int)patientNum);
                            }
                            else
                            {
                                Console.WriteLine("Wrong Tool, Sorry");
                            }
                            //if (((IPlayer)entity).currentTool.GetName == "Leech")
                            //    ((IPlayer)entity).ActivateTool((int)patientNum);
                        }
                }
            }
        }
        }

        public void OnDamageTaken(object sender, IEvent args)
        {
            if (health > 0)
            {
                health -= ((ReceiveDamageEvent)args).Damage[patientNum];
                if(symptoms.Count>1)
                    health -= ((ReceiveDamageEvent)args).Damage[patientNum];
                healthBar.UpdateHealth(health);
            }
               
            //Console.WriteLine(health + " " + patientNum);
        }

        private void Respawn()
        {
            if (isDead)
            {
                isDead = false;
                CreateNewIllness();
                symbolManager.AddIllness(illness, patientNum);
                death.OnDeath(false, patientNum);
                health = maxHealth;
                entityLocn = startPosition;
                healthBar.UpdateHealth(health);
                ((IEntity)healthBar).setPosition(healthBar.StartPos.X,healthBar.StartPos.Y);
            }
            if (activityEnded)
            {
                activityEnded = false;
                CreateNewIllness();
                symbolManager.AddIllness(illness, patientNum);
                health = maxHealth;
                entityLocn = startPosition;
                healthBar.UpdateHealth(health);
                ((IEntity)healthBar).setPosition(healthBar.StartPos.X, healthBar.StartPos.Y);
            }
        }
        public override void Update()
        {
            if (!initial)
            {
                initial = true;
                startPosition = entityLocn;
                healthBar.UpdateHealth(health);
                symbolManager.AddIllness(illness, patientNum);
            }
              
           if (health <= 0&&!isDead)
            {
                isDead = true;
                hasCollided = false;
                death.OnDeath(true,patientNum);
                Console.WriteLine(patientNum+" is Dead");
                setPosition(1111, 1111);
                ((IEntity)healthBar).setPosition(1111, 1111);
            }

            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                hasCollided = false;
            }
        }

        public void OnActivityEnd(object sender, IEvent args)
        {
            if (((ActivityEvent)args).Ended[patientNum])
            {
                hasCollided = false;
                activityEnded = true;
                setPosition(1111, 1111);
                ((IEntity)healthBar).setPosition(1111, 1111);
            }
        
        }

        public void OnTimerStart(object sender, IEvent args)
        {
            if (((TimerEvent)args).DictTimerEnd[patientNum])
                Respawn();
        }

        public void OnHeal(object sender, IEvent args)
        {
            if (health < maxHealth)
            {
                health += ((ReceiveHealEvent)args).Heal[patientNum];
                healthBar.UpdateHealth(health);
            }
        }
    }
}
