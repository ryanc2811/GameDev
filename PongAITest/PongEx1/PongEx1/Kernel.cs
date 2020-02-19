using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

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
        private IEntity Player;
        private IEntity AI;
        private ICollisionManager collisionManager;
        
        

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
            Player = entityManager.createPaddle();
            AI = entityManager.createAI((IBall)ball);
            //initialise SceneManager
            sceneManager = new SceneManager();
            collisionManager = new CollisionManager();
            ((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)ball);
            ((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)Player);
            ((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)AI);
            //add entities to list
            sceneManager.addEntity(ball);
            sceneManager.addEntity(Player);
            sceneManager.addEntity(AI);
            
            //set starting position of paddle 1
            Player.setPosition(0, 0);
            //set starting position of paddle 2
            AI.setPosition(1550, 0);

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
            Player.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for paddle 2 object
            AI.setTexture(Content.Load<Texture2D>("paddle"));
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
            Content.Unload();
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
            if (Keyboard.GetState().IsKeyDown(Keys.R))
                ((Ball)ball).Serve();
            sceneManager.Update();
            // TODO: Add your update logic here
            base.Update(gameTime);

            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            
            collisionManager.Update();
            // input
            //send player index one parameter to the GetKeyboardInputDirection Method and store return value in player 1 velocity
            Vector2 p1Velocity = Input.GetKeyboardInputDirection(PlayerIndex.One);
            //send player index two parameter to the GetKeyboardInputDirection Method and store return value in player 2 velocity
            //Vector2 p2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two);
            ((Paddle)Player).setVelocity(p1Velocity);
            //((Paddle)AI).setVelocity(p2Velocity);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
