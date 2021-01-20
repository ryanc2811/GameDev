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
        #region Data member Variables
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
        //DECLARE IEntity for the Score text object
        private IEntity score;
        //DECLARE an IEntity for displaying the Time left in the game
        private IEntity gameTimerEntity;
        //DECLARE IEntity for the Button that adds a bone saw tool the player
        private IEntity boneSawButton;
        //DECLARE IEntity for the Button that adds a leech tool the player
        private IEntity leechButton;
        //DECLARE IEntity for the Button that enables and disables the handbook
        private IEntity handBookButton;
        //DECLARE IEntity for the Button that resets the calculator on the handbook
        private IEntity resetButton;
        //DECLARE IEntity for the handbook entity
        private IEntity handBook;
        //DECLARE IEntity for the bonesaw symbol entity which is added to the calculator
        private IEntity boneSawSymbol;
        //DECLARE IEntity for the leech symbol entity which is added to the calculator
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
        //DECLARE IList of IEntity for healthbars
        private IList<IEntity> healthBars;
        //DECLARE an IList of IEntity for all the quick time containers
        private IList<IEntity> QTContainers;
        //DECLARE an IList of IEntity for all the quick time green rectangle object
        private IList<IEntity> QTGreens;
        //DECLARE an IList of IEntity for all the quick time lines
        private IList<IEntity> QTLines;
        //DECLARE an IList of IEntity for the containers that sit underneath the symbols
        private IList<IEntity> symbolContainers;
        //DECLARE an IList of IEntity for holding all the symbols 
        private IList<IEntity> symbols;
        //DECLARE an IList of IEventHandler for storing death handlers
        private IList<IEventHandler> deathHandlers;
        //DECLARE an IList of IEventHandler for storing damage handlers
        private IList<IEventHandler> damageHandlers;
        //DECLARE an IList of IEventHandler for storing heal handlers
        private IList<IEventHandler> healHandlers;
        //DECLARE an IList of IEventHandler for storing death timers
        private IList<IEventHandler> deathTimers;
        //DECLARE an IList of IEventHandler for storing activity handlers
        private IList<IEventHandler> activityHandlers;
        //DECLARE an IList of IToolBehaviours for storing tool behaviours
        private IList<IBehaviour> toolBehaviours;
        //DECLARE an IList of IEntity for storing buttons for each symptom
        private IList<IEntity> symptomButtons;
        //DECLARE an IList of IEntity for storing buttons for each bodypart
        private IList<IEntity> bodyPartButtons;
        //DECLARE an IEventHandler for the game timer
        private IEventHandler gameTimer;
        //DECLARE an IPatientHandler for handling the respawning of patients
        private IPatientHandler patientHandler;
        //DECLARE an IEventHandler for handling the interact event
        private IEventHandler interactHandler;
        //DECLARE an ISymbolHandler storing a reference to each symbol
        private ISymbolHandler symbolHandler;
        //DECLARE an IEventHandler for handling the game end event
        private IEventHandler gameEndHandler;
        //DECLARE an ISymbolManager for managing each symbol
        private ISymbolManager symbolManager;
        //DECLARE an IGameUI for handling the UI for score and the Game timer
        private IGameUI gameUI;
        //DECLARE an ITool for the bone saw object
        private ITool boneSaw;
        //DECLARE an ITool for the leech object
        private ITool Leech;

        //DECLARE a Vector2 array for storing the positions for each quick time object
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
            entityManager.AddSceneManager(sceneManager);
            //INSTANTIATE Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //INSTANTIATE Collision Manager
            collisionManager = new CollisionManager();
            //INSTANTIATE Input Manager
            inputManager = new InputManager();
            //INSTANTIATE ToolFactory
            toolFactory = new ToolFactory();
            //INSTANTIATE ToolBehaviourFactory
            toolBehaviourFactory = new BehaviourFactory();
            //INSTANTIATE patients list with a capacity of 2
            Patients = new List<IEntity>(2);
            //INSTANTIATE event Manager
            eventManager = new EventManager();
            //INSTANTIATE death handlers list
            deathHandlers = new List<IEventHandler>();
            //INSTANTIATE damage handlers list
            damageHandlers = new List<IEventHandler>();
            //INSTANTIATE death timers list
            deathTimers = new List<IEventHandler>();
            //INSTANTIATE heal handlers list
            healHandlers = new List<IEventHandler>();
            //INSTANTIATE activity handlers list
            activityHandlers = new List<IEventHandler>();
            //INSTANTIATE symbol handler
            symbolHandler = new SymbolHandler();
            //Initialise symbol containers
            InitialiseSymbolContainers();
            //Initialise symbols
            InitialiseSymbols();
            //Initialise walls
            InitialiseWalls();
            //Initialise buttons
            InitialiseButtons();
            //Initialise event handlers
            InitialiseEventHandlers();
            //Initialise tools
            InitialiseTools();
            //Initialise handbook
            InitialiseHandBook();
            //Initialise patient handler
            InitialisePatientHandler();
            //Initialise entities that will be recycled on restart
            InitialiseEntities();
            //Initialise tool bench
            InitialiseToolBench();
            //Initialise mouse object
            InitialiseMouseObj();
            //subscribe the kernel as a IGameEndListener
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)this).OnGameEnd);
            //Assign spritebatch from Scene Manager
            ((SceneManager)sceneManager).spriteBatch = spriteBatch;
            
            //INITIALIZE
            base.Initialize();
            
        }

        
        #region Entities that are recycled after restart
        /// <summary>
        /// This method initialises all the entities that will need to be initialised again on restart
        /// </summary>
        private void InitialiseEntities()
        {
            //initialise All Entities
            InitialisePlayer();
            InitialiseGameUI();
            InitialiseQuickTimeObjects();
            InitialiseToolBehaviours();
            InitialisePatients();
        }
        #endregion
        #region Restart Game
        /// <summary>
        /// This method handles the removing of certain entities from the game world and unsubscribes them from any events that they are linked to
        /// </summary>
        private void RestartGame()
        {
            //Removes the player from the scene manager
            entityManager.Terminate(player);
            //removes the player from input listeners
            inputManager.removeEventListener(InputDevice.Keyboard,((IInputListener)player).OnNewInput);
            //unsubscribes the player from collision
            ((ICollisionPublisher)collisionManager).Unsubscribe((ICollidable)player);
            //Removes the player as an Activity Event listener
            eventManager.RemoveEventListener(EventType.ActivityEvent,((IActivityListener)player).OnActivityEnd);
            //Removes the player as a Death Event listener
            eventManager.RemoveEventListener(EventType.DeathEvent, ((IDeathListener)player).OnDeath);
            //set the player to null
            player = null;
            //removes the score entity from the scene manager
            entityManager.Terminate(score);
            //set score entity to null
            score = null;
            //removes the game timer entity from the scene manager
            entityManager.Terminate(gameTimerEntity);
            //sceneManager.removeEntity(gameTimerEntity);
            //removes the game timer entity from a timer event listener
            eventManager.RemoveEventListener(EventType.GameTimerEvent, ((ITimerListener)gameTimerEntity).OnTimerStart);
            //sets the game timer to null
            gameTimerEntity = null;
            //sets the game ui to null
            gameUI = null;
            //for every patient in the patient list
            for (int i = 0; i < Patients.Count; i++)
            {
                //remove patient from scene manager
                entityManager.Terminate(Patients[i]);
                //remove patient as a damage event listener
                eventManager.RemoveEventListener(EventType.DamageEvent, ((IDamageListener)Patients[i]).OnDamageTaken);
                //remove the patient as a heal listener
                eventManager.RemoveEventListener(EventType.HealEvent, ((IHealListener)Patients[i]).OnHeal);
                //remove the patient as a activity event listener
                eventManager.RemoveEventListener(EventType.ActivityEvent, ((IActivityListener)Patients[i]).OnActivityEnd);
                //remove the patient as a death timer listener
                eventManager.RemoveEventListener(EventType.DeathTimerEvent, ((ITimerListener)Patients[i]).OnTimerStart);
                //remove the patient as a collision subscriber
                ((ICollisionPublisher)collisionManager).Unsubscribe((ICollidable)Patients[i]);
                //set the patient to null
                Patients[i] = null;
                //remove the health bar from the scene manager
                entityManager.Terminate(healthBars[i]);
                //set the health bar to null
                healthBars[i] = null;
                //remove the Qt container from scenemanager
                entityManager.Terminate(QTContainers[i]);
                //set the qt container to null
                QTContainers[i] = null;
                //remove the Quick time green area from scene manager
                entityManager.Terminate(QTGreens[i]);
                //set the Quick time green area to null
                QTGreens[i] = null;
                //remove the QT line from the scenemanager
                entityManager.Terminate(QTLines[i]);
                //set the Qt line to null
                QTLines[i] = null;
            }
            //for each tool behaviour in tool behaviours
            for (int i = 0; i < toolBehaviours.Count; i++)
            {
                //remove the tool behaviour as a death event listener
                eventManager.RemoveEventListener(EventType.DeathEvent, ((IDeathListener)toolBehaviours[i]).OnDeath);
                //if the behaviour is an input listener then remove it as a keyboard event listener
                if(toolBehaviours[i]is IInputListener)
                    inputManager.removeEventListener(InputDevice.Keyboard, ((IInputListener)toolBehaviours[i]).OnNewInput);
                //if the tool behaviour is an interact listener, then remove it from event manager as an interact listener
                if (toolBehaviours[i] is IInteractListener)
                    eventManager.RemoveEventListener(EventType.InteractEvent, ((IInteractListener)toolBehaviours[i]).OnInteract);
                //remove the tool behaviour as a game end event listener
                eventManager.RemoveEventListener(EventType.GameEndEvent, ((IGameEndListener)toolBehaviours[i]).OnGameEnd);
                //set tool behaviour to null
                toolBehaviours[i] = null;
            }
            //clear the patients list
            Patients.Clear();
            //intialise entities
            InitialiseEntities();
            //reload content
            base.Initialize();
            
        }
        /// <summary>
        /// method for listening to the game end event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnGameEnd(object sender, IEvent args)
        {
            //if the game has ended, restart the game
            RestartGame();
        }
        #endregion
        #region Player
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
            //add player to the event manager as a death event listener
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)player).OnDeath);
            //add interact handler to the player
            ((IPlayer)player).AddInteractHandler((IInteractHandler)interactHandler);
            //set the players initial position
            player.setPosition(800, 800);
        }
        #endregion
        #region GameUI
        /// <summary>
        /// initialises the UI for the game(score and timer)
        /// </summary>
        private void InitialiseGameUI()
        {
            //INSTANTIATE GameUI
            gameUI = new GameUI();
            //add game ui as an activity event listener
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)gameUI).OnActivityEnd);
            //create the score entity 
            score = entityManager.createEntity<Score>();
            //create the game timer entity
            gameTimerEntity = entityManager.createEntity<TimerUI>();
            //Add the game end handler to the game timer entity
            ((ITimerEntity)gameTimerEntity).AddGameEndHandler((IGameEndHandler)gameEndHandler);
            //Add game timer entity as a game timer event listener
            eventManager.AddEventListener(EventType.GameTimerEvent, ((ITimerListener)gameTimerEntity).OnTimerStart);
            //add score to the game UI
            gameUI.AddUIElement(score);
            //Add the game timer handler to the game ui
            gameUI.AddGameTimer((IGameTimer)gameTimer);
            //add the game timer entity to the scene manager
            sceneManager.addEntity(gameTimerEntity);
            //add the score entity to the scene manager
            sceneManager.addEntity(score);
            //set the initial position of the score
            score.setPosition(100, 50);
            //set the initial position of the game timer entity
            gameTimerEntity.setPosition(1300, 50);
            
        }
        #endregion
        #region Buttons
        /// <summary>
        /// Initialises Buttons
        /// </summary>
        private void InitialiseButtons()
        {
            //create Buttons
            boneSawButton = entityManager.createEntity<Button>();
            leechButton = entityManager.createEntity<Button>();
            handBookButton = entityManager.createEntity<Button>();
            resetButton = entityManager.createEntity<Button>();
            //subscribe the buttons as a collidable object
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
            //INTANTIATE symptom buttons list
            symptomButtons = new List<IEntity>();
            //INTANTIATE body part buttons list
            bodyPartButtons = new List<IEntity>();
            //iterate over each symptom in the symptom enum
            foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
            {
                //create a button
                IEntity button = entityManager.createEntity<Button>();
                //subscribe the button as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)button);
                //add the button as a mouse input listener
                inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)button).OnNewInput);
                //add the button to the symptoms button list
                symptomButtons.Add(button);
                //add the button to the scene manager
                sceneManager.addEntity(button);
                
            }
            //iterate over each bodypart in the bodypart enum
            foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
            {
                //create a button
                IEntity button = entityManager.createEntity<Button>();
                //subscribe the button as a collidable object
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)button);
                //add the button as a mouse input listener
                inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)button).OnNewInput);
                //add the button to the bodypart button list
                bodyPartButtons.Add(button);
                //add the button to the scene manager
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
                //set the event type of the death timer to death timer event
                ((IGameTimer)deathTimer).SetEventType(EventType.DeathTimerEvent);
                eventManager.AddEventHandler(deathTimer);
                IEventHandler damageHandler = new DamageHandler();
                eventManager.AddEventHandler(damageHandler);
                IEventHandler healHandler = new HealHandler();
                eventManager.AddEventHandler(healHandler);
                IEventHandler activityHandler = new ActivityHandler();
                eventManager.AddEventHandler(activityHandler);
            }
            //INSTANTIATE a game timer
            gameTimer = new GameTimer();
            //Set the event type to game timer event
            ((IGameTimer)gameTimer).SetEventType(EventType.GameTimerEvent);
            //add the game timer to the event manager
            eventManager.AddEventHandler(gameTimer);
            //INSTANTIATE an interact handler
            interactHandler = new InteractHandler();
            //add the handler to the event manager
            eventManager.AddEventHandler(interactHandler);
            //INSTANTIATE an game end handler
            gameEndHandler = new GameEndHandler();
            //add the handler to the event manager
            eventManager.AddEventHandler(gameEndHandler);
            //set the list of event handlers from event manager locally
            IList<IEventHandler> eventHandlers = eventManager.Handlers;
            //iterate over each handler in event handlers list
            foreach (IEventHandler handler in eventHandlers)
            {
                //add each handler to their corresponding list
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
        #region ToolBench
        /// <summary>
        /// Initialises Tool Bench
        /// </summary>
        private void InitialiseToolBench()
        {
            //create the tool bench object
            toolBench = entityManager.createEntity<ToolBench>();
            //add the bonesaw tool to the tools list inside tool bench
            ((IToolBench)toolBench).addTool(boneSaw);
            //add the leech tool to the tools list inside tool bench
            ((IToolBench)toolBench).addTool(Leech);
            //add the bonesaw button to the tool bench
            ((IToolBench)toolBench).SetToolButtons((IButton)boneSawButton, (IButton)leechButton);
            //subscribe the toolbench as a collidable object
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)toolBench);
            //add the tool bench to the scene
            sceneManager.addEntity(toolBench);
            //set the tool bench's initial position
            toolBench.setPosition(725, 100);
        }
        #endregion
        #region Tools
        /// <summary>
        /// Initialise Tools 
        /// </summary>
        private void InitialiseTools()
        {
            //Create a tool for bonesaw
            boneSaw = toolFactory.create("BoneSaw");
            //create a leech tool
            Leech = toolFactory.create("Leech");
            //Add the tool to the event manager as a death listener
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)boneSaw).OnDeath);
            //Add the tool to the event manager as a game end listener
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)boneSaw).OnGameEnd);
            //Add the tool to the event manager as a death listener
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)Leech).OnDeath);
            //Add the tool to the event manager as a game end listener
            eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)Leech).OnGameEnd);
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
                //INSTANTIATE a leech behaviour using the tool behaviour factory
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
                //subscribe the bonesawbehaviour class to the eventmanager as a game end listener object
                eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)boneSawBehaviour).OnGameEnd);
                //subscribe the leechBehaviour class to the eventmanager as a game end listener object
                eventManager.AddEventListener(EventType.GameEndEvent, ((IGameEndListener)leechBehaviour).OnGameEnd);
                //add the behaviour to the bonesaw tool object with reference to the patient number that owns it
                boneSaw.ReceiveJob(boneSawBehaviour, i);
                Leech.ReceiveJob(leechBehaviour, i);
                //add the behaviour to the local toolbehaviour list
                toolBehaviours.Add(boneSawBehaviour);
                toolBehaviours.Add(leechBehaviour);
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
                IEntity QTContainer = entityManager.createEntity<QTContainer>();
                IEntity QTLine = entityManager.createEntity<QTLine>();
                IEntity QTGreen = entityManager.createEntity<QTGreen>();
                //add the objects to the corresponding lists
                QTContainers.Add(QTContainer);
                QTLines.Add(QTLine);
                QTGreens.Add(QTGreen);
                //set the position of the quick time objects for when they are active
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
        #region PatientHandler
        /// <summary>
        /// Initialise the patient handler which handles when a patient can respawn
        /// </summary>
        private void InitialisePatientHandler()
        {
            //INSTANTIATE patient handler
            patientHandler = new PatientHandler();
            //for each patient in patients list
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //add a death timer to the patient handler
                patientHandler.AddGameTimer((IGameTimer)deathTimers[i], (PatientNum)i);
            }
            //add patient handler as a death listener
            eventManager.AddEventListener(EventType.DeathEvent, ((IDeathListener)patientHandler).OnDeath);
            //add patient handler as a activity event
            eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)patientHandler).OnActivityEnd);
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
                //add the patient to the event manager class as a heal listener object
                eventManager.AddEventListener(EventType.HealEvent, ((IHealListener)patient).OnHeal);
                //add the patient to the event manager class as an activity listener object
                eventManager.AddEventListener(EventType.ActivityEvent, ((IActivityListener)patient).OnActivityEnd);
                //add the patient to the event manager class as a death timer listener object
                eventManager.AddEventListener(EventType.DeathTimerEvent, ((ITimerListener)patient).OnTimerStart);
                //add entities to scene manager
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
        #region Walls
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
        #region Symbols
        private void InitialiseSymbols()
        {
            //INSTANTIATE symbols list of type IEntity
            symbols = new List<IEntity>();
            #region Symbols Next to Patients
            //iterate over each patient in patients
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //iterate over each symptom in the symptom enum
                foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
                {
                    
                    for (int j = 0; j < 2; j++)
                    {
                        //create a symptom symbol
                        IEntity symbol = entityManager.createEntity<SymptomSymbol>();
                        //set the symbols symptom the current sympom in the loop
                        ((ISymptomSymbol)symbol).Symptom = symptom;
                        //set the symbol type to symptom
                        ((ISymbol)symbol).SymbolType = SymbolType.Symptom;
                        //set the patient number of the symbol
                        ((ISymbol)symbol).Patient = (PatientNum)i;
                        //mark the symbol as not being used in the handbook
                        ((ISymbol)symbol).usedInHandbook = false;
                        //add the symbol to the symbol list
                        symbols.Add(symbol);
                        //add the symbol to the scene manager
                        sceneManager.addEntity(symbol);
                        //add the symbol to the symbol handler
                        symbolHandler.AddSymbol(symbol);
                        //set the symbol as inactive
                        ((ISymbol)symbol).SetActive(false);
                        //set the position of each symptom symbol
                        if (i == 0)
                            ((ISymbol)symbol).SetStartPos(symptomPos[i + j]);

                        if (i == 1)
                            ((ISymbol)symbol).SetStartPos(symptomPos[1 + i + j]);
                    }
                }
                //iterate over each bodypart in the body part enum
                foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
                {
                    //create a body part symbol
                    IEntity symbol = entityManager.createEntity<BodyPartSymbol>();
                    //set the body part to the current bodypart in the loop
                    ((IBodyPartSymbol)symbol).BodyPart = bodyPart;
                    //set the patient number of the symbol
                    ((ISymbol)symbol).Patient = (PatientNum)i;
                    //set the symbol type to bodypart
                    ((ISymbol)symbol).SymbolType = SymbolType.BodyPart;
                    //mark the symbol as not being used in the handbook
                    ((ISymbol)symbol).usedInHandbook = false;
                    //add the symbol to the symbols list
                    symbols.Add(symbol);
                    //add the symbol to the scenemanager
                    sceneManager.addEntity(symbol);
                    //add the symbol to the symbol handler
                    symbolHandler.AddSymbol(symbol);
                    //set the symbol as inactive
                    ((ISymbol)symbol).SetActive(false);
                    //set the active start position of the symbol
                    ((ISymbol)symbol).SetStartPos(bodyPartPos[i]);
                }
            }
            #endregion
            //Symbols being used in the handbook
            #region Handbook Symbols
            //iterate over each symptom in symptoms enum
            foreach (Symptom symptom in Enum.GetValues(typeof(Symptom)))
            {
                //create two symbols for each symptom
                for (int j = 0; j < 2; j++)
                {
                    //create symptom symbol 
                    IEntity symbol = entityManager.createEntity<SymptomSymbol>();
                    //Set the symbols syptom to the current symptom in the loop
                    ((ISymptomSymbol)symbol).Symptom = symptom;
                    //set the symbol type symptom
                    ((ISymbol)symbol).SymbolType = SymbolType.Symptom;
                    //mark the symbol as being used in the handbook
                    ((ISymbol)symbol).usedInHandbook = true;
                    //add the symbol to the symbols list
                    symbols.Add(symbol);
                    //add the symbol to the scenemanager
                    sceneManager.addEntity(symbol);
                    //add the symbol to the symbol handler
                    symbolHandler.AddSymbol(symbol);
                    //set the symbol as inactive
                    ((ISymbol)symbol).SetActive(false);
                    //set the start position for when the symbol is active
                    ((ISymbol)symbol).SetStartPos(symptomPosCalc[j]);
                }

            }
            //iterate over each bodypart in the body part enum
            foreach (BodyPart bodyPart in Enum.GetValues(typeof(BodyPart)))
            {
                //create a bodypart symbol
                IEntity symbol = entityManager.createEntity<BodyPartSymbol>();
                //set the bodypart of the symbol to the current bodypart in the loop
                ((IBodyPartSymbol)symbol).BodyPart = bodyPart;
                //set the symbol type to bodypart
                ((ISymbol)symbol).SymbolType = SymbolType.BodyPart;
                //mark the symbol as being used in the handbook
                ((ISymbol)symbol).usedInHandbook = true;
                //add the symbol to the symbols list
                symbols.Add(symbol);
                //add the symbol to the scene manager
                sceneManager.addEntity(symbol);
                //add the symbol to the symbol handler
                symbolHandler.AddSymbol(symbol);
                //set the symbol as inactive
                ((ISymbol)symbol).SetActive(false);
                //set the position for when the symbol is active
                ((ISymbol)symbol).SetStartPos(bodyPartPosCalc);
            }
            //create a symbol for the bone saw
            boneSawSymbol = entityManager.createEntity<ToolSymbol>();
            //create a symbol for the leech
            leechSymbol = entityManager.createEntity<ToolSymbol>();
            //set the tool type of the tool to bonesaw
            ((IToolSymbol)boneSawSymbol).Tool = ToolType.bonesaw;
            //set the tool type of the tool to leech
            ((IToolSymbol)leechSymbol).Tool = ToolType.leech;
            //add the symbol to the scenemanager
            sceneManager.addEntity(boneSawSymbol);
            //add the symbol to the scenemanager
            sceneManager.addEntity(leechSymbol);
            //mark the symbol as inactive
            ((ISymbol)boneSawSymbol).SetActive(false);
            ((ISymbol)leechSymbol).SetActive(false);
            //set the position of the symbol for when the symbol is active
            ((ISymbol)boneSawSymbol).SetStartPos(toolPos);
            ((ISymbol)leechSymbol).SetStartPos(toolPos);
            //INSTANTIATE the symbol manager
            symbolManager = new SymbolManager();
            //add the symbol handler to the symbol manager
            symbolManager.AddSymbols(symbolHandler);
            #endregion
        }
        #endregion
        #region Handbook
        /// <summary>
        /// initialises the handbook
        /// </summary>
        private void InitialiseHandBook()
        {
            //create the handbook entity
            handBook = entityManager.createEntity<HandBook>();
            //INSTANTIATE a illness calculator
            IIllnessCalculator illnessCalculator = new IllnessCalculator();
            foreach (IEntity button in symptomButtons)
            {
                //add each symbol to the handbook
                ((IHandBook)handBook).AddSymbolButton(SymbolType.Symptom, (IButton)button);
                //set the position of each button to be off screen
                button.setPosition(1111, 1111);
            }
            foreach (IEntity button in bodyPartButtons)
            {
                //add each symbol to the handbook
                ((IHandBook)handBook).AddSymbolButton(SymbolType.BodyPart, (IButton)button);
                //set the position of each button to be off screen
                button.setPosition(1111, 1111);
            }
            //add the symbol handler to the handbook
            ((IHandBook)handBook).AddSymbolHandler(symbolHandler);
            //add the illness calculator to the handbook
            ((IHandBook)handBook).AddIllnessCalculator(illnessCalculator);
            //add the tool symbols to the illness calculator
            illnessCalculator.AddToolSymbol(boneSawSymbol);
            illnessCalculator.AddToolSymbol(leechSymbol);
            //add the handbook button to the handbook ( which enables and disables the handbook)
            ((IHandBook)handBook).AddHandBookButton((IButton)handBookButton);
            //add the reset button to the handbook
            ((IHandBook)handBook).AddResetButton((IButton)resetButton);
            //add the handbook to the scenemanager
            sceneManager.addEntity(handBook);
            //set the handbooks position so its off screen
            handBook.setPosition(1111, 1111);
            
        }
        #endregion
        #region Symbol Containers
        /// <summary>
        /// initialies the containers for each symbol
        /// </summary>
        private void InitialiseSymbolContainers()
        {
            //INSTANTIATE the symbol containers list
            symbolContainers = new List<IEntity>();
            //for each patient in the patients list
            for (int i = 0; i < Patients.Capacity; i++)
            {
                //create 3 symbol containers next to each patient
                for (int j = 0; j < 3; j++)
                {
                    //create a symbol container
                    IEntity symbolContainer = entityManager.createEntity<Container>();
                    //add the symbol container to the symbol containers list
                    symbolContainers.Add(symbolContainer);
                    //add the symbol container to the scene manager
                    sceneManager.addEntity(symbolContainer);
                    //set the position of each symbol container
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
        #endregion
        #region Load Content
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //load texture for entities
            ((ITextEntity)score).SetFont(Content.Load<SpriteFont>("Text/Score"));
            ((ITextEntity)gameTimerEntity).SetFont(Content.Load<SpriteFont>("Text/Score"));
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
        #region Update
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
            //Update the death timers
            for (int i = 0; i < deathTimers.Count; i++)
            {
                ((IGameTimer)deathTimers[i]).Update(gameTime);
            }
            //update the game timer
            ((IGameTimer)gameTimer).Update(gameTime);
            //update the game UI
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
