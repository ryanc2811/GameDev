using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.Input;
using PongEx1.Tools;
using PongEx1.Entities.PatientStuff;
using PongEx1.Activity;
using PongEx1._Game.Events;
using PongEx1.Entities.Interacted;

namespace PongEx1.Entities
{
    class Player : GameXEntity, ICollidable, IInputListener,IPlayer,IActivityListener,IDeathListener
    {
        //DECLARE Array List for Input
        private IList<Keys> keyList;
        private IInteractHandler _InteractHandler;
        private float speed=10f;
        private float reducedSpeed;
        private Vector2 tempPos;
        private bool interact = false;
        private bool itemAdded = false;
        bool stopMoving = false;
        int currentPatientNum;
        bool gotInput = false;
        

        public Player()
        {
            layerDepth = 0.2f;
            reducedSpeed = speed *= 0.7f;
        }
        public ITool currentTool { get; set; }

  
        public bool Interact { get { return interact; } }
        public Rectangle getHitBox()
        {
            return new Rectangle((int)entityLocn.X, (int)entityLocn.Y, texture.Width, texture.Height);
        }

        public void onCollide(IEntity entity)
        {
            if(entity is IImmovable)
                entityLocn = tempPos;

            if(entity is Patient)
            {
                if (interact&&!itemAdded)
                {
                    itemAdded = true;
                }
                if (currentTool != null)
                {
                    if (interact && currentTool.GetName == "Leech")
                    {
                        _InteractHandler.OnInteract(true, ((Patient)entity).GetPatientNum);
                    }
                }
            }
        }
        public override void Update()
        {
            spriteOrigin = new Vector2(texture.Width / 2, texture.Height / 2);
            if (currentTool != null)
                currentTool.Update();
            
            if (velocity.X != 0 && velocity.Y != 0)
            {
                speed = reducedSpeed;
            }
            else
            {
                speed = 10;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.F))
            {
                gotInput = false;
            }
            if (!interact)
            {
                foreach(PatientNum num in Enum.GetValues(typeof(PatientNum)))
                {
                    _InteractHandler.OnInteract(false, num);
                }
            }
        }
        public void ActivateTool(int patientNum)
        {
            currentTool.setActive(true,patientNum);
            currentPatientNum = patientNum;
            Console.WriteLine(currentTool.GetName + " Used");
            if (currentTool.GetName == "BoneSaw")
                stopMoving = true;
        }
        public void OnNewInput(object sender, InputEventArgs args)
        {
            // Act on data:
            velocity = Vector2.Zero;
            keyList = args.PressedKeys;
            tempPos = entityLocn;
            interact = false;

            if (!stopMoving) {
                if (keyList.Contains(Keys.W))
                {
                rotation = MathHelper.ToRadians(0f);
                velocity.Y -= speed;
                //update the paddles position
                entityLocn.Y += velocity.Y;
                }
                else if (keyList.Contains(Keys.S))
                {
                    rotation = MathHelper.ToRadians(180f);
                    velocity.Y += speed;
                    //update the paddles position
                    entityLocn.Y += velocity.Y;
                }
                if (keyList.Contains(Keys.A))
                {
                    rotation = MathHelper.ToRadians(270f);
                    velocity.X -= speed;
                    //update the paddles position
                    entityLocn.X += velocity.X;
                }

                else if (keyList.Contains(Keys.D))
                {
                    rotation = MathHelper.ToRadians(90f);
                    velocity.X += speed;
                    //update the paddles position
                    entityLocn.X += velocity.X;
                }
                if (keyList.Contains(Keys.F) && !gotInput)
                {
                    interact = true;
                    gotInput = true;
                }
            }
        }
        public void AddInteractHandler(IInteractHandler interact)
        {
            _InteractHandler = interact;
        }
        public void RemoveInteractHandler()
        {
            _InteractHandler = null;
        }
        public void OnDeath(object sender, IEvent args)
        {
            if (((DeathEvent)args).Dead[(PatientNum)currentPatientNum])
                stopMoving = false;
        }

        public void OnActivityEnd(object sender, IEvent args)
        {
            if (((ActivityEvent)args).Ended[(PatientNum)currentPatientNum])
                stopMoving = false;
        }
    }
}
