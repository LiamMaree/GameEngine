using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GameEngine;
using SharpDX.Direct3D9;
namespace gameEngineTest
{
    public class Game1 : Game
    {
        
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        public static SceneManager sceneManager;
        public InputHandler inputHandler;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.PreferredBackBufferWidth = 800;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            sceneManager = new SceneManager();
            inputHandler = new InputHandler();

            TestScene test = new TestScene(inputHandler,_graphics);
            EmptyScene empty = new EmptyScene(inputHandler);
            sceneManager.AddScene("TEST", test);
            sceneManager.AddScene("EMPTY", empty);
            sceneManager.setCurrentScene("TEST");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            



            sceneManager.Load(this);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            sceneManager.Update(gameTime);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            sceneManager.Draw(_spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
