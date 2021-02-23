using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using GameEngine.Collision;
using GameEngine.Entities;
using GameEngine.EntityManagement;
using GameEngine.Scene;
using GameEngine.Input;
using GameEngine.BehaviourManagement;
using Pong.Entities;
using GameEngine.Animation_Stuff;
using Pong.State_Stuff;
using GameEngine.BehaviourManagement.StateMachine_Stuff;
using GameEngine.State_Stuff;
using Microsoft.Xna.Framework.Audio;
using GameEngine.Sound_Stuff;

namespace GameEngine.Kernel
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
        public const int SCREENWIDTH=1600;
        //DECLARE Screen Height
        public const int SCREENHEIGHT=900;

        //DECLARE Scene Manager 
        ISceneManager sceneManager;
        //DECLARE Entity Manager
        IEntityManager entityManager;
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;
        //DECLARE Input Manager
        private IInputManager inputManager;
        //DECLARE AIComponentManager
        private IAIComponentManager componentManager;
        //DECLARE AIComponent, called paddleLAI
        private IAIComponent paddleLStateMachine;
        //DECLARE AIComponent, called paddleRAI
        private IAIComponent paddleRStateMachine;
        //DECLARE AIComponent, called ballAI
        private IAIComponent ballStateMachine;
        private IAIComponent characterStateMachine;

        private IEntity paddleL;
        private IEntity paddleR;
        private IEntity ball;
        private IEntity character;

        private IStateFactory stateFactory;

        private IEntity characterStateText;
        private IEntity ballStateText;
        private IEntity paddleLStateText;
        private IEntity paddleRStateText;
        #endregion

        #region Constructor
        public Kernel()
        {
            //ASSIGN Graphics Device Manager
            graphics = new GraphicsDeviceManager(this);
            //DEFINE Screen Height
            graphics.PreferredBackBufferHeight = SCREENHEIGHT;
            //DEFINE Screen Width
            graphics.PreferredBackBufferWidth = SCREENWIDTH;
            Window.Position = new Point((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) - 
                (graphics.PreferredBackBufferWidth / 2), 
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) - 
                (graphics.PreferredBackBufferHeight / 2));
            graphics.ApplyChanges();
            //ASSING Content
            Content.RootDirectory = "Content";

            InstantiateMembers();
        }
        #endregion
        void InstantiateMembers()
        {
            //instantiate SceneManager
            sceneManager = new SceneManager();
            //instantiate EntityManager
            entityManager = new EntityManager();
            //instantiate Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //instantiate SceneManager
            sceneManager = new SceneManager();
            //instantiate Collision Manager
            collisionManager = new CollisionManager();
            //instantiate Input Manager
            inputManager = new InputManager();
            //instantiate AI Component Manager
            componentManager = new AIComponentManager();
            
            
            //instantiate Ball Entity
            ball = entityManager.CreateEntity<Ball>();
            //instantiate Ball AI
            ballStateMachine = componentManager.Create<BallStateMachine>();
            //instantiate Right Paddle Entity
            paddleR = entityManager.CreateEntity<Paddle>();
            //instantiate Paddle AI Component
            paddleRStateMachine = componentManager.Create<PaddleStateMachine>();
            //instantiate Left Paddle Entity
            paddleL = entityManager.CreateEntity<Paddle>();
            //instantiate Paddle AI Component
            paddleLStateMachine = componentManager.Create<PaddleStateMachine>();

            character = entityManager.CreateEntity<TopDownCharacter>();

            characterStateText = entityManager.CreateEntity<TextEntity>();

            characterStateMachine = componentManager.Create<CharacterStateMachine>();

            ballStateText = entityManager.CreateEntity<TextEntity>();
            paddleLStateText = entityManager.CreateEntity<TextEntity>();
            paddleRStateText = entityManager.CreateEntity<TextEntity>();
            //INSTANTIATE state factory
            stateFactory = new StateFactory();

        }
        #region Initialize
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Add all entities to collision Manager
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)ballStateMachine);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddleLStateMachine);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddleRStateMachine);
            //Add all entities to Input Manager
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddleLStateMachine).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddleRStateMachine).OnNewInput);

            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)ballStateMachine).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)characterStateMachine).OnNewInput);
            //add entities to list
            sceneManager.AddEntity(ball);
            sceneManager.AddEntity(paddleL);
            sceneManager.AddEntity(paddleR);
            sceneManager.AddEntity(character);
            sceneManager.AddEntity(characterStateText);
            sceneManager.AddEntity(ballStateText);
            sceneManager.AddEntity(paddleLStateText);
            sceneManager.AddEntity(paddleRStateText);
            //Initialise all entities
            sceneManager.Initialise();
            //Add Entities to statemachine
            paddleLStateMachine.SetAIUser((IAIUser)paddleL);
            paddleRStateMachine.SetAIUser((IAIUser)paddleR);
            ballStateMachine.SetAIUser((IAIUser)ball);
            characterStateMachine.SetAIUser((IAIUser)character);

            //populate statemachine with states
            ((IStateMachine)characterStateMachine).AddState((int)CharacterState.Idle, stateFactory.Create<CharacterIdleState>());
            ((IStateMachine)characterStateMachine).AddState((int)CharacterState.Move, stateFactory.Create<CharacterMoveState>());
            //Add text that displays the current state
            ((IStateMachine)characterStateMachine).AddStateText((ITextEntity)characterStateText);
            ((IStateMachine)ballStateMachine).AddStateText((ITextEntity)ballStateText);
            ((IStateMachine)paddleLStateMachine).AddStateText((ITextEntity)paddleLStateText);
            ((IStateMachine)paddleRStateMachine).AddStateText((ITextEntity)paddleRStateText);

            ((IStateMachine)ballStateMachine).AddState((int)BallState.Serve, stateFactory.Create<BallServeState>());
            ((IStateMachine)ballStateMachine).AddState((int)BallState.Bounce, stateFactory.Create<BallBounceState>());
            ((IStateMachine)ballStateMachine).AddState((int)BallState.Destroyed, stateFactory.Create<BallDestroyedState>());

            ((IStateMachine)paddleLStateMachine).AddState((int)PaddleState.Idle, stateFactory.Create<PaddleIdleState>());
            ((IStateMachine)paddleRStateMachine).AddState((int)PaddleState.Idle, stateFactory.Create<PaddleIdleState>());
            
            ((IStateMachine)paddleRStateMachine).AddState((int)PaddleState.Move, stateFactory.Create<PaddleMoveState>());
            ((IStateMachine)paddleLStateMachine).AddState((int)PaddleState.Move, stateFactory.Create<PaddleMoveState>());
            //initialise statemachines
            ballStateMachine.Initialise();
            paddleLStateMachine.Initialise();
            paddleRStateMachine.Initialise();
            characterStateMachine.Initialise();

            //set starting position entities
            characterStateText.SetPosition(500, 300);
            ballStateText.SetPosition(500, 100);
            paddleLStateText.SetPosition(100, 100);
            paddleRStateText.SetPosition(1000, 100);
            paddleL.SetPosition(0, 500);
            paddleR.SetPosition(1550, 500);
            character.SetPosition(775, 300);
            ball.SetPosition(500, 300);
            paddleL.Tag = "LeftPaddle";
            paddleR.Tag = "RightPaddle";
            //INITIALIZE
            base.Initialize();
            
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
            IDictionary<string, IAnimation> ballAnimations = new Dictionary<string, IAnimation>()
            {
                { "moveUp",new Animation(Content.Load<Texture2D>("square"),1)},
                { "moveDown",new Animation(Content.Load<Texture2D>("RedSquare"),1)}
            };
            ((IAnimatedSprite)ball).AddAnimations(ballAnimations);
            IDictionary<string, IAnimation> characterAnimations = new Dictionary<string, IAnimation>()
            {
                { "moveUp",new Animation(Content.Load<Texture2D>("moveUp"),3)},
                { "moveDown",new Animation(Content.Load<Texture2D>("moveDown"),3)},
                { "moveLeft",new Animation(Content.Load<Texture2D>("moveLeft"),3)},
                { "moveRight",new Animation(Content.Load<Texture2D>("moveRight"),3)},
                { "idle",new Animation(Content.Load<Texture2D>("idle"),1)}
            };
            ((IAnimatedSprite)character).AddAnimations(characterAnimations);
            paddleL.SetTexture(Content.Load<Texture2D>("paddle"));
            paddleR.SetTexture(Content.Load<Texture2D>("paddle"));

            IDictionary<string, ISound> ballSounds = new Dictionary<string, ISound>()
            {
                {"bounce", new Sound(Content.Load<SoundEffect>("Sounds/bounceSound"))}
            };
            ((ISoundEmitter)ball).AddSounds(ballSounds);
            ((ITextEntity)characterStateText).SetFont(Content.Load<SpriteFont>("Fonts/StateText"));
            ((ITextEntity)ballStateText).SetFont(Content.Load<SpriteFont>("Fonts/StateText"));
            ((ITextEntity)paddleRStateText).SetFont(Content.Load<SpriteFont>("Fonts/StateText"));
            ((ITextEntity)paddleLStateText).SetFont(Content.Load<SpriteFont>("Fonts/StateText"));
            //Tell ai components that content has been loaded
            componentManager.OnContentLoad();
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


            // TODO: Add your update logic here
            base.Update(gameTime);

            //Update entities in scene manager array
            sceneManager.Update(gameTime);
            //Update all ai components
            componentManager.Update(gameTime);
            //update Collision Manager
            collisionManager.Update();
            //update Input Manager
            inputManager.Update();
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Begin Drawing
            spriteBatch.Begin();
            //Draw entities
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
    }

}
