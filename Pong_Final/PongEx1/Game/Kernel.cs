using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using PongEx1.Collision;
using PongEx1.Entities;
using PongEx1.EntityManagement;
using PongEx1.Scene;
using PongEx1.Input;

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
        SceneManager sceneManager;
        //DECLARE Entity Manager
        IEntityManager entityManager;
        //DECLARE ball 1
        private IEntity ball1;
        //DECLARE ball 2
        private IEntity ball2;
        //DECLARE paddle for first player
        private IEntity paddle1;
        //DECLARE paddle for second player
        private IEntity paddle2;
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;
        //DECLARE Input Menager
        private IInputManager inputManager;
        //DECLARE boolean for exit
        public static bool exit;
        //DELCARE Listener Switch
        private bool listenerSwitch;
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
            //initialise SceneManager
            sceneManager = new SceneManager();
            //initialise EntityManager
            entityManager = new EntityManager();
            //initialize Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //initialise reference to ball class
            ball1 = entityManager.createBall();
            //initialise reference to paddle class
            paddle1 = entityManager.createPaddle();
            paddle2 = entityManager.createPaddle();
            //initialise SceneManager
            sceneManager = new SceneManager();
            //initialize Collision Manager
            collisionManager = new CollisionManager();
            //initialize Input Manager
            inputManager = new InputManager();
            //Add all entieties to collision Manager 
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)ball1);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddle1);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddle2);
            //Add all entieties to Input Manager
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)ball1).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddle1).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddle2).OnNewInput);
            //add entities to list
            sceneManager.addEntity(ball1);
            sceneManager.addEntity(paddle1);
            sceneManager.addEntity(paddle2);
            //Assign spritebatch from Scene Manager
            sceneManager.spriteBatch = spriteBatch;
            //set starting position of paddle 1
            paddle1.setPosition(0, 0);
            //set starting position of paddle 2
            paddle2.setPosition(1550, 0);

            //serve the ball
            ball1.Initialise();

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
            //load texture for paddle 1 object
            paddle1.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for paddle 2 object
            paddle2.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for ball object
            ball1.setTexture(Content.Load<Texture2D>("square"));
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

            //if Player wants to exit
            if (exit)
            {
                //Exit
                Exit();
            }
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
            //Draw entieties
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion
    }

}
