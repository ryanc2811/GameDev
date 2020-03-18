using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using PongEx1.Game_Engine.Collision;
using PongEx1.Game_Engine.Entities;
using PongEx1.Game_Engine.EntityManagement;
using PongEx1.Game_Engine.Scene;
using PongEx1.Game_Engine.Input;
using PongEx1.Entities;

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
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;
        //DECLARE Input Menager
        private IInputManager inputManager;
        private IEntity player;
        private IEntity wallLeft;
        private IEntity wallRight;
        private IEntity wallTop;
        private IEntity wallBottom;
        private List<IEntity> Walls;
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
            //initialise SceneManager
            sceneManager = new SceneManager();
            //initialize Collision Manager
            collisionManager = new CollisionManager();
            //initialize Input Manager
            inputManager = new InputManager();
            Walls = new List<IEntity>(4);
            //initialise reference Entities

            player = entityManager.createPlayer();
            for (int i = 0; i < Walls.Capacity; i++)
            {
                IEntity Wall = entityManager.createWall();
                Walls.Add(Wall);
                ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)Walls[i]);
                //add entities to list
                sceneManager.addEntity(Walls[i]);
                if (i == 0)
                {
                    //set starting position of wall
                    Walls[i].setPosition(0, 0);
                }
                if (i == 1)
                {
                    //set starting position of wall
                    Walls[i].setPosition(111, 500);
                }
                if (i == 2)
                {
                    //set starting position of wall
                    Walls[i].setPosition(444, 12);
                }
                if (i == 3)
                {
                    //set starting position of wall
                    Walls[i].setPosition(222, 44);
                }

            }
            
           
            //Add all entities to collision Manager 
            ((ICollisionPublisher)collisionManager).Subscribe((ICollidable)player);
           
            //Add all entieties to Input Manager
            inputManager.addEventListener(InputDevice.Keyboard, ((IInputListener)player).OnNewInput);

            //add entities to list
            sceneManager.addEntity(player);
            
            //Assign spritebatch from Scene Manager
            sceneManager.spriteBatch = spriteBatch;
            //set starting position of player
            player.setPosition(0, 0);
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
            player.setTexture(Content.Load<Texture2D>("square"));
            for (int i = 0; i < Walls.Capacity; i++)
            {
                Walls[i].setTexture(Content.Load<Texture2D>("paddle"));
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
