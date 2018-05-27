using Engine.Components;
using Engine.Manager;
using Engine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private InputSystem inputSystem;
        private RenderSystem renderSystem;
        Viewport viewport;
        private PhysicsSystem physicsSystem;
        private CollisionDetectionSystem collisionDetectionSystem;
        private int count;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ComponentManager cm = ComponentManager.Instance;

            inputSystem = new InputSystem();
            renderSystem = new RenderSystem();
            physicsSystem = new PhysicsSystem();

            collisionDetectionSystem = new CollisionDetectionSystem();

            Viewport viewport = new Viewport();
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
            CreateEntities();

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
            if (!collisionDetectionSystem.CollisionOccured)
            {
                Console.WriteLine("Colliding");
            }

              
                
                

            // TODO: Add your update logic here
            inputSystem.Update(gameTime);
            physicsSystem.Update(gameTime);
            collisionDetectionSystem.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            renderSystem.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }

        private void CreateEntities()
        {
            var playerSprite = Content.Load<Texture2D>("Illuminati");
            var enemySprite = Content.Load<Texture2D>("Dorito");


            ComponentManager cm = ComponentManager.Instance;



            //Create Player
            int playerId = cm.CreateNewEntity(new SpriteComponent() { Texture = playerSprite, Rectangle = new Rectangle(0,0,30,30) });
            cm.AddComponentToEntity(playerId, new PositionComponent() { Position = new Vector2(0, 0)});
            cm.AddComponentToEntity(playerId, new InputComponent() { Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D });
            cm.AddComponentToEntity(playerId, new CollisionComponent());
            cm.AddComponentToEntity(playerId, new PlayerComponent());

            

            //Create Enemy
            int enemyId = cm.CreateNewEntity(new SpriteComponent() { Texture = enemySprite, Rectangle = new Rectangle(50, 60, 30, 30) });
            cm.AddComponentToEntity(enemyId, new PositionComponent() { Position = new Vector2(20, 0) });
            cm.AddComponentToEntity(enemyId, new CollisionComponent());
            cm.AddComponentToEntity(enemyId, new EnemyComponent());
        }
    }
}
