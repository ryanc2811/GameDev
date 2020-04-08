using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Entities.Button;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Mouse;
using PongEx1.Entities.PatientStuff;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.EntityManagement;
using PongEx1.Game_Engine.Input;
using PongEx1.Game_Engine.Scene;
using PongEx1.Tools;
using System;
using System.Collections.Generic;

namespace PongEx1
{
    // This is the main type for your game.
    public class Kernel : Game
    {
        #region Variables
        //DECLARE Graphics Device Manager 
        GraphicsDeviceManager graphics;
        //DECLARE Sprite Batch
        SpriteBatch spriteBatch;
        //DECLARE Screen Width
        public static int ScreenWidth;
        //DECLARE Screen Height
        public static int ScreenHeight;
        //DECLARE Scene Manager 
        ISceneManager sceneManager;
        //DECLARE Entity Manager
        IEntityManager entityManager;
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;
        //DECLARE Input Manager
        private IInputManager inputManager;
        //DECLARE IEventManager
        private IEventManager eventManager;
        //DECLARE IEntity for player object
        private IEntity player;
        //DECLARE IEntity for toolbench object
        private IEntity toolBench;
        //DECLARE IEntity for boneSaw Button
        private IEntity boneSawButton;
        //DECLARE IEntity for mouse object
        private IEntity mouse;
        //DECLARE IToolFactory for creating tools
        private IToolFactory toolFactory;
        //DECLARE IToolBehaviourFactory for creating tool behaviours
        private IBehaviourFactory toolBehaviourFactory;
        //DECLARE list of IEntity for walls
        private List<IEntity> Walls;
        //DECLARE list of IEntity for patients
        private List<IEntity> Patients;
        //DECLARE an IList of IEntity for all the quick time containers
        private IList<IEntity> QTContainers;
        //DECLARE an IList of IEntity for all the quick time green rectangle object
        private IList<IEntity> QTGreens;
        //DECLARE an IList of IEntity for all the quick time lines
        private IList<IEntity> QTLines;
        //DECLARE an IList of IEventHandler for storing death handlers
        private IList<IEventHandler> deathHandlers;
        //DECLARE an IList of IEventHandler for storing damage handlers
        private IList<IEventHandler> damageHandlers;
        //DECLARE an IList of IEventHandler for storing activity handlers
        private IList<IEventHandler> activityHandlers;
        //DECLARE an IList of IToolBehaviours for storing tool behaviours
        private IList<IBehaviour> toolBehaviours;
        private IEventHandler gameTimer;
        private IPatientHandler patientHandler;
        //DECLARE an ITool for the bone saw object
        private ITool boneSaw;
        private Vector2[] QTContainerPos ={ new Vector2(100, 300),new Vector2(1300, 300) };
        private Vector2[] QTLinePos ={ new Vector2(100, 310), new Vector2(1300, 310) };
        private Vector2[] QTGreenPos = { new Vector2(150, 310), new Vector2(1350, 310) };
        #endregion

        #region Constructor
        public Kernel()
        {
            //ASSIGN Graphics Device Manager
            graphics = new GraphicsDeviceManager(this);
            //DEFINE Screen Height
            graphics.PreferredBackBufferHeight = 900;
            //DEFINE Screen Width
            graphics.PreferredBackBufferWidth = 1600;
            //ASSING Content
            Content.RootDirectory = "Content";
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            //INSTANTIATE SceneManager
            sceneManager = new SceneManager();
            //INSTANTIATEEntityManager
            entityManager = new EntityManager();
            //INSTANTIATE Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //INSTANTIATE SceneManager
            sceneManager = new SceneManager();
            //INSTANTIATE Collision Manager
            collisionManager = new CollisionManager();
            //INSTANTIATE Input Manager
            inputManager = new InputManager();
            //INSTANTIATE ToolFactory
            toolFactory = new ToolFactory();
            //INSTANTIATE ToolBehaviourFactory
            toolBehaviourFactory = new ToolBehaviourFactory();
            //INSTANTIATE patients list
            Patients = new List<IEntity>(2);
            //create tools
            boneSaw = toolFactory.create("BoneSaw");
            eventManager = new EventManager();
            deathHandlers = new List<IEventHandler>();
            damageHandlers= new List<IEventHandler>();
            activityHandlers=new List<IEventHandler>();
            //initialise All Entities
            InitialiseEventHandlers();
            InitialiseQuickTimeObjects();
            InitialiseToolBehaviours();
            InitialisePlayer();
            InitialiseButtons();
            InitialiseToolBench();
            InitialiseMouseObj();
            InitialiseWalls();
            InitialisePatients();
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)boneSaw).OnDeath);
            //Assign spritebatch from Scene Manager
            ((SceneManager)sceneManager).spriteBatch = spriteBatch;
          
            //INITIALIZE
            base.Initialize();
            
        }

        /// <summary>
        /// Initialises Player
        /// </summary>
        private void InitialisePlayer()
        {
            //create player object
            player = entityManager.createEntity<Player>();
            //add player to scene
            sceneManager.addEntity(player);
            //subscribe player to Collision publisher
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)player);
            //add player to input manager as an input listener object
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)player).OnNewInput);
            //add player to the event manager as an activity event listener
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)player).OnActivityChange);
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)player).OnDeath);
            //set the players initial position
            player.setPosition(800, 800);
        }
        /// <summary>
        /// Initialises Tool Bench
        /// </summary>
        private void InitialiseToolBench()
        {
            //create the tool bench object
            toolBench = entityManager.createEntity<ToolBench>();
            //add the bonesaw tool to the tools list inside tool bench
            ((IToolBench)toolBench).addTool(boneSaw);
            //add the bonesaw button to the tool bench
            ((IToolBench)toolBench).SetToolButtons((IButton)boneSawButton);
            //subscribe the toolbench as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)toolBench);
            //add the tool bench to the scene
            sceneManager.addEntity(toolBench);
            //set the tool bench's initial position
            toolBench.setPosition(725, 100);
        }
        /// <summary>
        /// Initialises Buttons
        /// </summary>
        private void InitialiseButtons()
        {
            //create a bonesaw button
            boneSawButton = entityManager.createEntity<Button>();
            //subscribe the button as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)boneSawButton);
            //add the button to the inputmanager class as a mouse input listener object
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)boneSawButton).OnNewInput);
            //add the button to the scene
            sceneManager.addEntity(boneSawButton);
            //set the buttons initial position
            boneSawButton.setPosition(1700, 1125);
        }
        /// <summary>
        /// Initialises Mouse object
        /// </summary>
        private void InitialiseMouseObj()
        {
            //create the mouse IEntity object
            mouse = entityManager.createEntity<MouseEntity>();
            //subscribe the mouse as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)mouse);
            //add the mouse to the input manager class as a mouse input listener
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)mouse).OnNewInput);
            //add the mouse to the scene
            sceneManager.addEntity(mouse);
        }
        /// <summary>
        /// Initialises Event Handlers
        /// </summary>
        private void InitialiseEventHandlers()
        {
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //INSTANTIATE and add all handler objects to the event handler
                IEventHandler deathHandler = new DeathHandler();
                eventManager.AddEventHandler(deathHandler);
                IEventHandler damageHandler = new DamageHandler();
                eventManager.AddEventHandler(damageHandler);
                IEventHandler activityHandler = new ActivityHandler();
                eventManager.AddEventHandler(activityHandler);
            }
            gameTimer = new GameTimer();
            eventManager.AddEventHandler(gameTimer);
            IList<IEventHandler> eventHandlers = eventManager.Handlers;

            foreach (IEventHandler handler in eventHandlers)
            {
                if (handler.GetType is EventType.DamageEvent)
                {
                    damageHandlers.Add(handler);
                }
                if (handler.GetType is EventType.ActivityEvent)
                {
                    activityHandlers.Add(handler);

                }
               if (handler.GetType is EventType.DeathEvent)
                {
                    deathHandlers.Add(handler);
                }
            }
        }
        /// <summary>
        /// Initialises Quick Time Objects
        /// </summary>
        private void InitialiseQuickTimeObjects()
        {
            //INSTANTIATE quick time event objects lists
            QTContainers = new List<IEntity>();
            QTGreens = new List<IEntity>();
            QTLines = new List<IEntity>();
            //for every patient in the patients list
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //create quick time objects
                IEntity QTContainer=entityManager.createEntity<QTContainer>();
                IEntity QTLine=entityManager.createEntity<QTLine>();
                IEntity QTGreen=entityManager.createEntity<QTGreen>();
                //add the objects to the corresponding lists
                QTContainers.Add(QTContainer);
                QTLines.Add(QTLine);
                QTGreens.Add(QTGreen);
                //set the patient number to which the quick time object belongs to
                ((IQuickTimeObj)QTLines[i]).SetPatientNum(i);
                ((IQuickTimeObj)QTGreens[i]).SetPatientNum(i);
                ((IQuickTimeObj)QTContainers[i]).SetPatientNum(i);
                ((IQuickTimeObj)QTLines[i]).SetActivePosition(QTLinePos[i]);
                ((IQuickTimeObj)QTContainers[i]).SetActivePosition(QTContainerPos[i]);
                ((IQuickTimeObj)QTGreens[i]).SetActivePosition(QTGreenPos[i]);
                //subscribe the QTLine and QT green objects as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)QTLine);
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)QTGreen);
                //add the QTLine object to the event manager as an Activity Event Listener
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)QTLine).OnActivityChange);
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)QTGreen).OnActivityChange);
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)QTContainer).OnActivityChange);
                //add the Quick time objects to the scene
                sceneManager.addEntity(QTContainer);
                sceneManager.addEntity(QTGreen);
                sceneManager.addEntity(QTLine);
                //set the initial position of all quick time objects (OFF SCREEN)
                QTContainer.setPosition(1100, 1300);
                QTGreen.setPosition(1150, 1310);
                QTLine.setPosition(1100, 1310);
            }
        }
        /// <summary>
        /// Initialises ToolBehaviours
        /// </summary>
        private void InitialiseToolBehaviours()
        {
            //INSTANTIATE toolbehaviours list
            toolBehaviours = new List<IBehaviour>();
            //for every patient in the patients list
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //INSTANTIATE a bonesaw behaviour using the tool behaviour factory
                IBehaviour boneSawBehaviour = toolBehaviourFactory.Create<BoneSawBehaviour>();
                //add the Quick time event object to the bonesaw behaviour class
                ((BoneSawBehaviour)boneSawBehaviour).SetQTItems(QTContainers[i], QTLines[i], QTGreens[i]);
                //add a damage handler to the bonesawbehaviour class
                boneSawBehaviour.AddDamageHandler((IDamageHandler)damageHandlers[i]);
                //add an activity handler to the bonesawbehaviour class
                boneSawBehaviour.AddActivityHandler((IActivityHandler)activityHandlers[i]);
                //subscribe the bonesawbehaviour class to the inputmanager as a keyboard input listener
                inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)boneSawBehaviour).OnNewInput);
                //subscribe the bonesawbehaviour class to the eventmanager as a DeathListener object
                eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)boneSawBehaviour).OnDeath);
                //add the behaviour to the bonesaw tool object with reference to the patient number that owns it
                boneSaw.receiveJob(boneSawBehaviour, i);
                //add the behaviour to the local toolbehaviour list
                toolBehaviours.Add(boneSawBehaviour);
            }
        }
        /// <summary>
        /// Initialises Patients
        /// </summary>
        private void InitialisePatients()
        {
            patientHandler = new PatientHandler();
            patientHandler.AddGameTimer((IGameTimer)gameTimer);
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)patientHandler).OnDeath);
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //create a patient
                IEntity patient = entityManager.createEntity<Patient>();
                //add the patient to the local patients list
                Patients.Add(patient);
                //add the patient to the collision manager as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)Patients[i]);
                //add the death handler object to the patient
                ((Patient)patient).AddDeathHandler((IDeathHandler)deathHandlers[i]);
                //set the patient number of the patient
                ((Patient)patient).SetPatientNum((PatientNum)i);
                //add the patient to the event manager class as a damage listener object
                eventManager.AddEventListener(EventType.DamageEvent, ((IDamageListener)Patients[i]).OnDamageTaken);
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)Patients[i]).OnActivityChange);
                eventManager.AddEventListener(EventType.TimerEvent, ((IGameTimerListener)Patients[i]).OnTimerStart);
                //add entities to list
                sceneManager.addEntity(Patients[i]);
                if (i == 0)
                {
                    //set starting position of left Patient
                    Patients[i].setPosition(100, 400);
                }
                if (i == 1)
                {
                    //set starting position of right Patient
                    Patients[i].setPosition(1400, 400);
                }
            }
        }
        /// <summary>
        /// Initialises walls
        /// </summary>
        private void InitialiseWalls()
        {
            //INSTANTIATE the walls list
            Walls = new List<IEntity>(4);
            for (int i = 0; i < Walls.Capacity; i++)
            {
                //create a wall
                IEntity Wall = entityManager.createEntity<Wall>();
                //add wall to walls list
                Walls.Add(Wall);
                //subscribe the wall the the collision publisher as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)Walls[i]);
                //add wall to scene
                sceneManager.addEntity(Walls[i]);
                //set the position of each wall depending on the i variable
                if (i == 0)
                {
                    //set starting position of left wall
                    Walls[i].setPosition(-20, 0);
                }
                if (i == 1)
                {
                    //set starting position of right wall
                    Walls[i].setPosition(1620, 0);
                }
                if (i == 2)
                {
                    //set starting position of the top wall
                    Walls[i].setPosition(0, -20);
                }
                if (i == 3)
                {
                    //set starting position of the bottom wall
                    Walls[i].setPosition(0, 920);
                }

            }
        }
        #endregion

        #region Load Content
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //load texture for entities
            player.setTexture(Content.Load<Texture2D>("square"));
            toolBench.setTexture(Content.Load<Texture2D>("ToolBench"));
            boneSawButton.setTexture(Content.Load<Texture2D>("BoneSaw"));
            mouse.setTexture(Content.Load<Texture2D>("cursor"));
            for (int i = 0; i < Walls.Capacity; i++)
            {
                if(i==0||i==1)
                    Walls[i].setTexture(Content.Load<Texture2D>("WallVertical"));
                if(i==2||i==3)
                    Walls[i].setTexture(Content.Load<Texture2D>("WallHorizontal"));
            }
            for (int i = 0; i < Patients.Capacity; i++)
            {
                Patients[i].setTexture(Content.Load<Texture2D>("Patient"));
            }
            for (int i = 0; i < QTContainers.Count; i++)
            {
                QTContainers[i].setTexture(Content.Load<Texture2D>("QTContainer"));
            }
            for (int i = 0; i < QTGreens.Count; i++)
            {
                QTGreens[i].setTexture(Content.Load<Texture2D>("QTGreen"));
            }
            for (int i = 0; i < QTLines.Count; i++)
            {
                QTLines[i].setTexture(Content.Load<Texture2D>("QTLine"));
            }
        }
        #endregion

        #region UnloadContent
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }
        #endregion

        #region update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //if User use button Escape exit the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //Update entities in scene manager array
            sceneManager.Update();
            // TODO: Add your update logic here
            base.Update(gameTime);
            //Hold the screen widht and Height
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            //update Collision Manager
            collisionManager.Update();
            //update Input Manager
            inputManager.Update();
            ((IGameTimer)gameTimer).Update(gameTime);
        }
        #endregion

        #region Draw
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //Make the background blue
            GraphicsDevice.Clear(Color.Gray);
            //Begin Drawing
            spriteBatch.Begin();
            //Draw entities
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
    }

}
