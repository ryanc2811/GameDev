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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;
        SceneManager sceneManager;
        IEntityManager entityManager;
        private IEntity ball;
        private IEntity paddle1;
        private IEntity paddle2;
        private ICollisionManager collisionManager;
        private IInputManager inputManager;
        public static bool exit;
        private bool listenerSwitch;
        //DECLARE Vector 2 for storing the location if the paddle, name it paddleLocn
        //private Vector2 paddleLocn;
        //DECLARE Vector 2 for storing the location if the ball, name it ballLocn
        //private Vector2 ballLocn;

        public Kernel()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
            Content.RootDirectory = "Content";
        }

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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //initialise reference to ball class
            ball = entityManager.createBall();
            //initialise reference to paddle class
            paddle1 = entityManager.createPaddle();
            paddle2 = entityManager.createPaddle();
            //initialise SceneManager
            sceneManager = new SceneManager();
            collisionManager = new CollisionManager();
            inputManager = new InputManager();
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)ball);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddle1);
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)paddle2);
            inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)ball).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddle1).OnNewInput);
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)paddle2).OnNewInput);
            //add entities to list
            sceneManager.addEntity(ball);
            sceneManager.addEntity(paddle1);
            sceneManager.addEntity(paddle2);
            sceneManager.spriteBatch = spriteBatch;
            //set starting position of paddle 1
            paddle1.setPosition(0, 0);
            //set starting position of paddle 2
            paddle2.setPosition(1550, 0);

            //serve the ball
            ball.Initialise();

            base.Initialize();
            
        }

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
            ball.setTexture(Content.Load<Texture2D>("square"));
        }

        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }

        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            sceneManager.Update();
            // TODO: Add your update logic here
            base.Update(gameTime);

            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            if (exit)
            {
                Exit();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                listenerSwitch=!listenerSwitch;
                Console.WriteLine(listenerSwitch);
                if (listenerSwitch)
                {
                    inputManager.addEventListener(InputDevice.Mouse, ((IInputListener)ball).OnNewInput);
                   
                }
                if(!listenerSwitch)
                {
                    inputManager.removeEventListener(InputDevice.Mouse, ((IInputListener)ball).OnNewInput);
                }
                
            }
            
            collisionManager.Update();
            inputManager.Update();
         
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
    
}
