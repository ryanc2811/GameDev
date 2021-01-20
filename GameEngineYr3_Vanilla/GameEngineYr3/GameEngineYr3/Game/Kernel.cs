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

namespace GameEngine
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
        SceneManager sceneManager;
        //DECLARE Entity Manager
        IEntityManager entityManager;
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;
        //DECLARE Input Menager
        private IInputManager inputManager;
        int fishCount = 0;

        private IEntity inputSquare;
        private IEntity collisionSquare;
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
            //initialise SceneManager
            sceneManager = new SceneManager();
            //initialise EntityManager
            entityManager = new EntityManager();
            //initialize Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //initialise SceneManager
            sceneManager = new SceneManager();
            //initialize Collision Manager
            collisionManager = new CollisionManager();
            //initialize Input Manager
            inputManager = new InputManager();

            inputSquare = entityManager.createEntity<EntityTest>();
            inputSquare.setPosition(SCREENWIDTH / 2,SCREENHEIGHT / 2);
            collisionSquare = entityManager.createEntity<EntityTest>();
            collisionSquare.setPosition((SCREENWIDTH / 2)+200, SCREENHEIGHT / 2);
            //Add all entities to collision Manager
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)inputSquare);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)collisionSquare);
            //Add all entities to Input Manager
            inputManager.addEventListener(InputDevice.Keyboard,((IInputListener)inputSquare).OnNewInput);
            //add entities to list
            sceneManager.addEntity(inputSquare);
            sceneManager.addEntity(collisionSquare);
            //Assign spritebatch from Scene Manager
            sceneManager.spriteBatch = spriteBatch;
            //Initialise all entities
            foreach(IEntity entity in sceneManager.EntityList)
            {
                entity.Initialise();
            }
            //INITIALIZE
            base.Initialize();
            
        }
        #endregion


        void CreateFish(Random random)
        {
            IEntity fish = entityManager.createEntity<EntityTest>();
            sceneManager.addEntity(fish);
            fish.setTexture(Content.Load<Texture2D>("Orange_Fish"));
            fish.setPosition(random.Next(SCREENWIDTH - Content.Load<Texture2D>("Orange_Fish").Width), random.Next(SCREENHEIGHT - Content.Load<Texture2D>("Orange_Fish").Height));
            fish.Initialise();
            fishCount++;
            Console.WriteLine(fishCount);
        }
        #region Load Content
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //load texture for entities
            inputSquare.setTexture(Content.Load<Texture2D>("square"));
            collisionSquare.setTexture(Content.Load<Texture2D>("square"));
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                CreateFish(random);
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
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
    }

}
