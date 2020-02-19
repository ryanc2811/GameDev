using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Ball _ball;
        private Paddle _paddle1;
        private Paddle _paddle2;
        //DECLARE Vector 2 for storing the location if the paddle, name it paddleLocn
        //private Vector2 paddleLocn;
        //DECLARE Vector 2 for storing the location if the ball, name it ballLocn
        //private Vector2 ballLocn;
       
        public Kernel()
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;

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
            ScreenWidth = GraphicsDevice.Viewport.Height;
            //initialise reference to ball class
            _ball = new Ball();
            //initialise reference to paddle class
            _paddle1 = new Paddle();
            _paddle2 = new Paddle();
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //load texture for paddle 1 object
            _paddle1.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for paddle 2 object
            _paddle2.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for ball object
            _ball.setTexture(Content.Load<Texture2D>("square"));
            //set starting position of paddle 1
            _paddle1.setPosition(0,0);
            //set starting position of paddle 2
            _paddle2.setPosition(1550, 0);
            _ball.setPosition(ScreenWidth / 2, ScreenHeight / 2);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            base.Update(gameTime);
            //send player index one parameter to the GetKeyboardInputDirection Method and store return value in player 1 velocity
            Vector2 p1Velocity= Input.GetKeyboardInputDirection(PlayerIndex.One);
            //send player index two parameter to the GetKeyboardInputDirection Method and store return value in player 2 velocity
            Vector2 p2Velocity = Input.GetKeyboardInputDirection(PlayerIndex.Two);
            //call update from ball class
            _ball.Update();

            //call update from paddle class, pass player 1 velocity
            _paddle1.Update(p1Velocity);
            
            //call update from paddle class, pass player 2 velocity
            _paddle2.Update(p2Velocity);
            

            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Height;
            
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            _ball.draw(spriteBatch);
            _paddle1.draw(spriteBatch);
            _paddle2.draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
