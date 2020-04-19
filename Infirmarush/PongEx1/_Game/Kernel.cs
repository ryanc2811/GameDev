using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PongEx1._Game.Behaviour;
using PongEx1._Game.Events;
using PongEx1._Game.Timer;
using PongEx1.Activity;
using PongEx1.Entities;
using PongEx1.Entities._Symbols;
using PongEx1.Entities.Button;
using PongEx1.Entities.Damage;
using PongEx1.Entities.Hand_Book;
using PongEx1.Entities.Healing;
using PongEx1.Entities.Interacted;
using PongEx1.Entities._Mouse;
using PongEx1.Entities.PatientStuff;
using PongEx1.Entities.PatientStuff.Health_Bar;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.EntityManagement;
using PongEx1.Game_Engine.Input;
using PongEx1.Game_Engine.Scene;
using PongEx1.Illness;
using PongEx1.Tools;
using PongEx1.Tools.Tool_Behaviour;
using System;
using System.Collections.Generic;
using PongEx1._Game.Game_UI;
using PongEx1._Game.GameEnd;

namespace PongEx1
{
    // This is the main type for your game.
    public class Kernel : Game,IGameEndListener
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
        private IEntity score;
        private IEntity gameTimerEntity;
        //DECLARE IEntity for boneSaw Button
        private IEntity boneSawButton;
        private IEntity leechButton;
        private IEntity handBookButton;
        private IEntity resetButton;
        private IEntity handBook;
        private IEntity boneSawSymbol;
        private IEntity leechSymbol;
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
        private IList<IEntity> healthBars;
        //DECLARE an IList of IEntity for all the quick time containers
        private IList<IEntity> QTContainers;
        //DECLARE an IList of IEntity for all the quick time green rectangle object
        private IList<IEntity> QTGreens;
        //DECLARE an IList of IEntity for all the quick time lines
        private IList<IEntity> QTLines;
        private IList<IEntity> symbolContainers;
        private IList<IEntity> symbols;
        //DECLARE an IList of IEventHandler for storing death handlers
        private IList<IEventHandler> deathHandlers;
        //DECLARE an IList of IEventHandler for storing damage handlers
        private IList<IEventHandler> damageHandlers;
        private IList<IEventHandler> healHandlers;
        private IList<IEventHandler> deathTimers;
        //DECLARE an IList of IEventHandler for storing activity handlers
        private IList<IEventHandler> activityHandlers;
        //DECLARE an IList of IToolBehaviours for storing tool behaviours
        private IList<IBehaviour> toolBehaviours;
        private IList<IEntity> symptomButtons;
        private IList<IEntity> bodyPartButtons;
        private IEventHandler gameTimer;
        private IPatientHandler patientHandler;
        private IEventHandler interactHandler;
        private ISymbolHandler symbolHandler;
        private IEventHandler gameEndHandler;
        ISymbolManager symbolManager;
        IGameUI gameUI;
        //DECLARE an ITool for the bone saw object
        private ITool boneSaw;
        private ITool Leech;

        private Vector2[] QTContainerPos ={ new Vector2(125, 275),new Vector2(1275, 275) };
        private Vector2[] QTLinePos ={ new Vector2(125, 285), new Vector2(1275, 285) };
        private Vector2[] QTGreenPos = { new Vector2(175, 285), new Vector2(1325, 285) };
        //Positions for the symptoms and body part symbols that sit next to each patient
        private Vector2[] symptomPos = { new Vector2(30, 280), new Vector2(30, 380), new Vector2(1500, 280), new Vector2(1500, 380) };
        private Vector2[] bodyPartPos = { new Vector2(30, 480),new Vector2(1500,480)};
        //Positions for each symbol used in the calculator
        private Vector2[] symptomPosCalc = { new Vector2(820, 240), new Vector2(944, 240) };
        private Vector2 bodyPartPosCalc = new Vector2(1058, 240);
        private Vector2 toolPos = new Vector2(1200, 240);
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
            toolBehaviourFactory = new BehaviourFactory();
            //create tools
            Patients = new List<IEntity>(2);
            boneSaw = toolFactory.create("BoneSaw");
            Leech = toolFactory.create("Leech");
            eventManager = new EventManager();
            deathHandlers = new List<IEventHandler>();
            damageHandlers = new List<IEventHandler>();
            deathTimers = new List<IEventHandler>();
            healHandlers = new List<IEventHandler>();
            activityHandlers = new List<IEventHandler>();
            symbolHandler = new SymbolHandler();
            InitialiseSymbolContainers();
            InitialiseSymbols();
            symbolManager = new SymbolManager();
            symbolManager.AddSymbols(symbolHandler);
            InitialiseWalls();
           
            InitialiseButtons();
            InitialiseEventHandlers();
            InitialiseHandBook();
            patientHandler = new PatientHandler();
            for (int i = 0; i < Patients.Capacity; i++)
            {
                patientHandler.AddGameTimer((IGameTimer)deathTimers[i],(PatientNum)i);
            }
            
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)patientHandler).OnDeath);
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)patientHandler).OnActivityEnd);
            InitialiseEntities();
            
            InitialiseToolBench();
            InitialiseMouseObj();
            
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)boneSaw).OnDeath);
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)boneSaw).OnGameEnd);
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)Leech).OnDeath);
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)Leech).OnGameEnd);
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)this).OnGameEnd);
            //Assign spritebatch from Scene Manager
            ((SceneManager)sceneManager).spriteBatch = spriteBatch;
            
            //INITIALIZE
            base.Initialize();
            
        }
        private void InitialiseEntities()
        {
            //initialise All Entities
            InitialisePlayer();
            InitialiseGameUI();
            InitialiseQuickTimeObjects();
            InitialiseToolBehaviours();
            InitialisePatients();
        }
        #region Restart Game
        private void RestartGame()
        {
            sceneManager.removeEntity(player);
            inputManager.removeEventListener(InputDevice.Keyboard,((IInputListener)player).OnNewInput);
            ((ICollisionPublisher)collisionManager).Unsubscribe((ICollidable)player);
            eventManager.RemoveEventListener(EventType.ActivityEvent,((IActivityListener)player).OnActivityEnd);
            eventManager.RemoveEventListener(EventType.DeathEvent, ((IDeathListener)player).OnDeath);
            ((IPlayer)player).RemoveInteractHandler();
            player = null;
            sceneManager.removeEntity(score);
            score = null;
            sceneManager.removeEntity(gameTimerEntity);
            eventManager.RemoveEventListener(EventType.GameTimerEvent, ((ITimerListener)gameTimerEntity).OnTimerStart);
            gameTimerEntity = null;
            gameUI = null;
            for (int i = 0; i < Patients.Count; i++)
            {
                sceneManager.removeEntity(Patients[i]);
                eventManager.RemoveEventListener(EventType.DamageEvent, ((IDamageListener)Patients[i]).OnDamageTaken);
                eventManager.RemoveEventListener(EventType.HealEvent, ((IHealListener)Patients[i]).OnHeal);
                eventManager.RemoveEventListener(EventType.ActivityEvent, ((IActivityListener)Patients[i]).OnActivityEnd);
                eventManager.RemoveEventListener(EventType.DeathTimerEvent, ((ITimerListener)Patients[i]).OnTimerStart);
                ((ICollisionPublisher)collisionManager).Unsubscribe((ICollidable)Patients[i]);
                Patients[i] = null;
                sceneManager.removeEntity(healthBars[i]);
                healthBars[i] = null;
                sceneManager.removeEntity(QTContainers[i]);
                QTContainers[i] = null;
                sceneManager.removeEntity(QTGreens[i]);
                QTGreens[i] = null;
                sceneManager.removeEntity(QTLines[i]);
                QTLines[i] = null;
                
            }
            for (int i = 0; i < toolBehaviours.Count; i++)
            {
                eventManager.RemoveEventListener(EventType.DeathEvent, ((IDeathListener)toolBehaviours[i]).OnDeath);
                if(toolBehaviours[i]is IInputListener)
                    inputManager.removeEventListener(InputDevice.Keyboard, ((IInputListener)toolBehaviours[i]).OnNewInput);
                if (toolBehaviours[i] is IInteractListener)
                    eventManager.RemoveEventListener(EventType.InteractEvent, ((IInteractListener)toolBehaviours[i]).OnInteract);
                eventManager.RemoveEventListener(EventType.GameEndEvent, ((IGameEndListener)toolBehaviours[i]).OnGameEnd);
            }
            Patients.Clear();
            InitialiseEntities();
            LoadContent();
            
        }
        public void OnGameEnd(object sender, IEvent args)
        {
            RestartGame();
        }
        #endregion
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
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)player).OnActivityEnd);
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)player).OnDeath);
            ((IPlayer)player).AddInteractHandler((IInteractHandler)interactHandler);
            //set the players initial position
            player.setPosition(800, 800);
        }
        private void InitialiseGameUI()
        {
            gameUI = new GameUI();
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)gameUI).OnActivityEnd);
            score = entityManager.createEntity<Score>();
            gameTimerEntity = entityManager.createEntity<TimerUI>();
            ((ITimerEntity)gameTimerEntity).AddGameEndHandler((IGameEndHandler)gameEndHandler);
            eventManager.AddEventListener(EventType.GameTimerEvent, ((ITimerListener)gameTimerEntity).OnTimerStart);
            gameUI.AddUIElement(score);
            gameUI.AddGameTimer((IGameTimer)gameTimer);
            sceneManager.addEntity(gameTimerEntity);
            sceneManager.addEntity(score);
            score.setPosition(100, 50);
            gameTimerEntity.setPosition(1300, 50);
            
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
            ((IToolBench)toolBench).addTool(Leech);
            //add the bonesaw button to the tool bench
            ((IToolBench)toolBench).SetToolButtons((IButton)boneSawButton,(IButton)leechButton);
            //subscribe the toolbench as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)toolBench);
            //add the tool bench to the scene
            sceneManager.addEntity(toolBench);
            //set the tool bench's initial position
            toolBench.setPosition(725, 100);
        }
        #region Buttons
        /// <summary>
        /// Initialises Buttons
        /// </summary>
        private void InitialiseButtons()
        {
            //create a bonesaw button
            boneSawButton = entityManager.createEntity<Button>();
            leechButton = entityManager.createEntity<Button>();
            handBookButton = entityManager.createEntity<Button>();
            resetButton = entityManager.createEntity<Button>();
            //subscribe the button as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)boneSawButton);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)leechButton);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)handBookButton);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)resetButton);
            //add the button to the inputmanager class as a mouse input listener object
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)boneSawButton).OnNewInput);
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)leechButton).OnNewInput);
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)handBookButton).OnNewInput);
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)resetButton).OnNewInput);
            //add the button to the scene
            sceneManager.addEntity(boneSawButton);
            sceneManager.addEntity(leechButton);
            sceneManager.addEntity(handBookButton);
            sceneManager.addEntity(resetButton);
            //set the buttons initial position
            boneSawButton.setPosition(1700, 1125);
            leechButton.setPosition(1900, 1125);
            handBookButton.setPosition(1500, 50);
            resetButton.setPosition(1111, 1111);
            symptomButtons = new List<IEntity>();
            bodyPartButtons = new List<IEntity>();
            foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
            {
                IEntity button = entityManager.createEntity<Button>();
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)button);
                inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)button).OnNewInput);
                symptomButtons.Add(button);
                sceneManager.addEntity(button);
                
            }
            foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
            {
                IEntity button = entityManager.createEntity<Button>();
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)button);
                inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)button).OnNewInput);
                bodyPartButtons.Add(button);
                sceneManager.addEntity(button);
            }
        }
        #endregion
        #region Mouse
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
        #endregion
        #region EventHandler
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
                IEventHandler deathTimer = new GameTimer();
                ((IGameTimer)deathTimer).SetEventType(EventType.DeathTimerEvent);
                eventManager.AddEventHandler(deathTimer);
                IEventHandler damageHandler = new DamageHandler();
                eventManager.AddEventHandler(damageHandler);
                IEventHandler healHandler = new HealHandler();
                eventManager.AddEventHandler(healHandler);
                IEventHandler activityHandler = new ActivityHandler();
                eventManager.AddEventHandler(activityHandler);
            }
  
            gameTimer = new GameTimer();
            ((IGameTimer)gameTimer).SetEventType(EventType.GameTimerEvent);
            eventManager.AddEventHandler(gameTimer);
            interactHandler = new InteractHandler();
            eventManager.AddEventHandler(interactHandler);
            gameEndHandler = new GameEndHandler();
            eventManager.AddEventHandler(gameEndHandler);
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
                if (handler.GetType is EventType.HealEvent)
                {
                    healHandlers.Add(handler);
                }
                if(handler.GetType is EventType.DeathTimerEvent)
                {
                    deathTimers.Add(handler);
                }
            }
            
        }
        #endregion
        #region Quick-Time Objects
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
                ((IQuickTimeObj)QTLines[i]).SetActivePosition(QTLinePos[i]);
                ((IQuickTimeObj)QTContainers[i]).SetActivePosition(QTContainerPos[i]);
                ((IQuickTimeObj)QTGreens[i]).SetActivePosition(QTGreenPos[i]);
                //subscribe the QTLine and QT green objects as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)QTLine);
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)QTGreen);

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
        #endregion
        #region Tool Behaviours
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
                IBehaviour leechBehaviour = toolBehaviourFactory.Create<LeechBehaviour>();
                //add the Quick time event object to the bonesaw behaviour class
                ((BoneSawBehaviour)boneSawBehaviour).SetQTItems(QTContainers[i], QTLines[i], QTGreens[i]);
                //add a damage handler to the bonesawbehaviour class
                ((IToolBehaviour)boneSawBehaviour).AddDamageHandler((IDamageHandler)damageHandlers[i]);
                //add an activity handler to the bonesawbehaviour class
                ((IToolBehaviour)boneSawBehaviour).AddActivityHandler((IActivityHandler)activityHandlers[i]);
                //add a damage handler to the bonesawbehaviour class
                ((IToolBehaviour)leechBehaviour).AddDamageHandler((IDamageHandler)damageHandlers[i]);
                ((IToolBehaviour)leechBehaviour).AddHealHandler((IHealHandler)healHandlers[i]);
                //add an activity handler to the bonesawbehaviour class
                ((IToolBehaviour)leechBehaviour).AddActivityHandler((IActivityHandler)activityHandlers[i]);
                //subscribe the bonesawbehaviour class to the inputmanager as a keyboard input listener
                inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)boneSawBehaviour).OnNewInput);
                //subscribe the bonesawbehaviour class to the eventmanager as a DeathListener object
                eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)boneSawBehaviour).OnDeath);
                //subscribe the leechBehaviour class to the eventmanager as a DeathListener object
                eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)leechBehaviour).OnDeath);
                //subscribe the leechBehaviour class to the eventmanager as a InteractListener object
                eventManager.AddEventListener(EventType.InteractEvent, ((IInteractListener)leechBehaviour).OnInteract);
                eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)boneSawBehaviour).OnGameEnd);
                eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)leechBehaviour).OnGameEnd);
                //add the behaviour to the bonesaw tool object with reference to the patient number that owns it
                boneSaw.receiveJob(boneSawBehaviour, i);
                Leech.receiveJob(leechBehaviour, i);
                //add the behaviour to the local toolbehaviour list
                toolBehaviours.Add(boneSawBehaviour);
                toolBehaviours.Add(leechBehaviour);
            }
        }
        #endregion
        #region Patient
        /// <summary>
        /// Initialises Patients
        /// </summary>
        private void InitialisePatients()
        {
          
            healthBars = new List<IEntity>();
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //create a patient
                IEntity patient = entityManager.createEntity<Patient>();
                IEntity healthBar = entityManager.createEntity<HealthBar>();
                //add the patient to the local patients list
                Patients.Add(patient);
                healthBars.Add(healthBar);
                //add the patient to the collision manager as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)patient);
                //add the death handler object to the patient
                ((Patient)patient).AddDeathHandler((IDeathHandler)deathHandlers[i]);
                //set the patient number of the patient
                
                ((Patient)patient).SetPatientNum((PatientNum)i);
                ((Patient)patient).SetHealthBar((IHealthBar)healthBar);
                ((Patient)patient).AddSymbolManager(symbolManager);
                //add the patient to the event manager class as a damage listener object
                eventManager.AddEventListener(EventType.DamageEvent, ((IDamageListener)patient).OnDamageTaken);
                eventManager.AddEventListener(EventType.HealEvent, ((IHealListener)patient).OnHeal);
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)patient).OnActivityEnd);
                eventManager.AddEventListener(EventType.DeathTimerEvent, ((ITimerListener)patient).OnTimerStart);
                //add entities to list
                sceneManager.addEntity(patient);
                sceneManager.addEntity(healthBar);
                if (i == 0)
                {
                    //set starting position of left Patient
                    patient.setPosition(170, 400);
                    healthBar.setPosition(120, 365);
                }
                if (i == 1)
                {
                    //set starting position of right Patient
                    patient.setPosition(1395, 400);
                    healthBar.setPosition(1450, 365);
                }
            }
        }
        #endregion
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
        private void InitialiseSymbols()
        {
            symbols = new List<IEntity>();
            #region Symbols Next to Patients
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //Create Symptom Symbols
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    IEntity symbol;
                    for (int j = 0; j < 2; j++)
                    {
                        symbol = entityManager.createEntity<SymptomSymbol>();
                        ((ISymptomSymbol)symbol).Symptom = symptom;
                        ((ISymbol)symbol).SymbolType = SymbolType.Symptom;
                        ((ISymbol)symbol).Patient = (PatientNum)i;
                        ((ISymbol)symbol).usedInHandbook = false;
                        symbols.Add(symbol);
                        sceneManager.addEntity(symbol);
                        symbolHandler.AddSymbol(symbol);
                        ((ISymbol)symbol).SetActive(false);
                        if (i == 0)
                            ((ISymbol)symbol).SetStartPos(symptomPos[i + j]);

                        if (i == 1)
                            ((ISymbol)symbol).SetStartPos(symptomPos[1 + i + j]);
                    }
                }
                //create Body Part Symbols
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    IEntity symbol;
                    symbol = entityManager.createEntity<BodyPartSymbol>();
                    ((IBodyPartSymbol)symbol).BodyPart = bodyPart;
                    ((ISymbol)symbol).Patient = (PatientNum)i;
                    ((ISymbol)symbol).SymbolType = SymbolType.BodyPart;
                    ((ISymbol)symbol).usedInHandbook = false;
                    symbols.Add(symbol);
                    sceneManager.addEntity(symbol);
                    symbolHandler.AddSymbol(symbol);
                    ((ISymbol)symbol).SetActive(false);
                    ((ISymbol)symbol).SetStartPos(bodyPartPos[i]);
                }
            }
            #endregion
            #region Handbook Symbols
            foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
            {
                IEntity symbol;
                for (int j = 0; j < 2; j++)
                {
                    symbol = entityManager.createEntity<SymptomSymbol>();
                    ((ISymptomSymbol)symbol).Symptom = symptom;
                    ((ISymbol)symbol).SymbolType = SymbolType.Symptom;
                    ((ISymbol)symbol).usedInHandbook = true;
                    symbols.Add(symbol);
                    sceneManager.addEntity(symbol);
                    symbolHandler.AddSymbol(symbol);
                    ((ISymbol)symbol).SetActive(false);
                    ((ISymbol)symbol).SetStartPos(symptomPosCalc[j]);
                }
            }
            //create Body Part Symbols
            foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
            {
                IEntity symbol;
                symbol = entityManager.createEntity<BodyPartSymbol>();
                ((IBodyPartSymbol)symbol).BodyPart = bodyPart;
                ((ISymbol)symbol).SymbolType = SymbolType.BodyPart;
                ((ISymbol)symbol).usedInHandbook = true;
                symbols.Add(symbol);
                sceneManager.addEntity(symbol);
                symbolHandler.AddSymbol(symbol);
                ((ISymbol)symbol).SetActive(false);
                ((ISymbol)symbol).SetStartPos(bodyPartPosCalc);
            }
            #endregion
        }
        private void InitialiseHandBook()
        {
            handBook = entityManager.createEntity<HandBook>();
            IIllnessCalculator illnessCalculator = new IllnessCalculator();
            boneSawSymbol = entityManager.createEntity<ToolSymbol>();
            leechSymbol = entityManager.createEntity<ToolSymbol>();
            ((IToolSymbol)boneSawSymbol).Tool = ToolType.bonesaw;
            ((IToolSymbol)leechSymbol).Tool = ToolType.leech;
            foreach (IEntity button in symptomButtons)
            {
                ((IHandBook)handBook).AddSymbolButton(SymbolType.Symptom, (IButton)button);
                button.setPosition(1111, 1111);
            }
            foreach (IEntity button in bodyPartButtons)
            {
                ((IHandBook)handBook).AddSymbolButton(SymbolType.BodyPart, (IButton)button);
                button.setPosition(1111, 1111);
            }
            ((IHandBook)handBook).AddSymbolHandler(symbolHandler);
            ((IHandBook)handBook).AddIllnessCalculator(illnessCalculator);
            illnessCalculator.AddToolSymbol(boneSawSymbol);
            illnessCalculator.AddToolSymbol(leechSymbol);
            ((IHandBook)handBook).AddHandBookButton((IButton)handBookButton);
            ((IHandBook)handBook).AddResetButton((IButton)resetButton);
            sceneManager.addEntity(handBook);
            sceneManager.addEntity(boneSawSymbol);
            sceneManager.addEntity(leechSymbol);
            handBook.setPosition(1111, 1111);
            boneSawSymbol.setPosition(1111, 1111);
            leechSymbol.setPosition(1111, 1111);
        }
        private void InitialiseSymbolContainers()
        {
            symbolContainers = new List<IEntity>();
            for (int i = 0; i < Patients.Capacity; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    IEntity symbolContainer = entityManager.createEntity<Container>();
                    symbolContainers.Add(symbolContainer);
                    sceneManager.addEntity(symbolContainer);
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            symbolContainer.setPosition(30, 280);
                        }
                        if (j == 1)
                        {
                            symbolContainer.setPosition(30, 380);
                        }
                        if (j == 2)
                        {
                            symbolContainer.setPosition(30, 480);
                        }
                    }
                    if (i == 1)
                    {
                        if (j == 0)
                        {
                            symbolContainer.setPosition(1500, 280);
                        }
                        if (j == 1)
                        {
                            symbolContainer.setPosition(1500, 380);
                        }
                        if (j == 2)
                        {
                            symbolContainer.setPosition(1500, 480);
                        }
                    }
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
            ((ITextEntity)score).setFont(Content.Load<SpriteFont>("Text/Score"));
            ((ITextEntity)gameTimerEntity).setFont(Content.Load<SpriteFont>("Text/Score"));
            player.setTexture(Content.Load<Texture2D>("square"));
            toolBench.setTexture(Content.Load<Texture2D>("ToolBench"));
            boneSawButton.setTexture(Content.Load<Texture2D>("BoneSaw"));
            leechButton.setTexture(Content.Load<Texture2D>("Leech"));
            mouse.setTexture(Content.Load<Texture2D>("cursor"));
            handBookButton.setTexture(Content.Load<Texture2D>("HandBookButton"));
            leechSymbol.setTexture(Content.Load<Texture2D>("Leech"));
            boneSawSymbol.setTexture(Content.Load<Texture2D>("BoneSaw"));
            resetButton.setTexture(Content.Load<Texture2D>("Reset"));
            for (int i = 0; i < symbols.Count; i++)
            {
                if (((ISymbol)symbols[i]).SymbolType == SymbolType.Symptom)
                {
                    if (((ISymptomSymbol)symbols[i]).Symptom == Symptom.infection)
                        symbols[i].setTexture(Content.Load<Texture2D>("Infection"));
                    if (((ISymptomSymbol)symbols[i]).Symptom == Symptom.nausea)
                        symbols[i].setTexture(Content.Load<Texture2D>("Nausea"));

                }
                if (((ISymbol)symbols[i]).SymbolType == SymbolType.BodyPart)
                {
                    if (((IBodyPartSymbol)symbols[i]).BodyPart == BodyPart.leg)
                        symbols[i].setTexture(Content.Load<Texture2D>("Leg"));
                    if (((IBodyPartSymbol)symbols[i]).BodyPart == BodyPart.arm)
                        symbols[i].setTexture(Content.Load<Texture2D>("Arm"));
                    if (((IBodyPartSymbol)symbols[i]).BodyPart == BodyPart.head)
                        symbols[i].setTexture(Content.Load<Texture2D>("Head"));
                }
            }
            for (int i = 0; i < symptomButtons.Count; i++)
            {
                if(i==0)
                    symptomButtons[i].setTexture(Content.Load<Texture2D>("Infection"));
                if (i == 1)
                    symptomButtons[i].setTexture(Content.Load<Texture2D>("Nausea"));
            }
            for (int i = 0; i < bodyPartButtons.Count; i++)
            {
                if (i == 0)
                    bodyPartButtons[i].setTexture(Content.Load<Texture2D>("Leg"));
                if (i == 1)
                    bodyPartButtons[i].setTexture(Content.Load<Texture2D>("Arm"));
                if (i == 2)
                    bodyPartButtons[i].setTexture(Content.Load<Texture2D>("Head"));
            }
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
            for (int i = 0; i < healthBars.Count; i++)
            {
                healthBars[i].setTexture(Content.Load<Texture2D>("HealthBar"));
            }
            for (int i = 0; i < symbolContainers.Count; i++)
            {
                symbolContainers[i].setTexture(Content.Load<Texture2D>("SymbolContainer"));
            }
            handBook.setTexture(Content.Load<Texture2D>("HandBook"));
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
            for (int i = 0; i < deathTimers.Count; i++)
            {
                ((IGameTimer)deathTimers[i]).Update(gameTime);
            }
            
            ((IGameTimer)gameTimer).Update(gameTime);
            gameUI.Update();
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
            spriteBatch.Begin(SpriteSortMode.BackToFront,null);
            //Draw entities
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        #endregion
    }

}
