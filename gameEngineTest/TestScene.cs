using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace gameEngineTest
{
    internal class TestScene : IScenes
    {
        InputHandler inputHandler;
        
        FollowCamera camera = new(Vector2.Zero);
        GraphicsDeviceManager _graphics;
        SongManager songManager;
        SoundEffectManager soundManager;
        SpriteManager spriteManager;
        
        public TestScene(GraphicsDeviceManager _graphics)
        {
            this._graphics = _graphics;
        }
        public void Initialize(Game game)
        {
            inputHandler = new InputHandler();
            songManager = new SongManager(100);
            soundManager = new SoundEffectManager();
            spriteManager = new SpriteManager();
            soundManager.AddSound("testEffect", "effect", game);
            songManager.AddSong("testSong", "song", game);
            songManager.SetCurrentSong("testSong");
            
            spriteManager.AddSprite(new Player("Player","Image1", new Vector2(400, 200), new Vector2(50, 50), inputHandler));
            spriteManager.AddSprite(new UIButtons("button", "Image1", new Vector2(400, 400), new Vector2(50, 50), inputHandler));
        }
        public void Update(GameTime gameTime)
        {
            inputHandler.Update();
            spriteManager.Update(gameTime);
            camera.Follow(spriteManager.GetSpriteByName("Player"), new Vector2(_graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight));
            inputHandler.setCameraTranslation(camera.translation);

            



        }
        public void Load(Game game)
        {
            spriteManager.Load(game);
            

        }
        public void Draw(SpriteBatch batch)
        {
            
            batch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: camera.translation);
            spriteManager.Draw(batch);
            batch.End();
        }
    }
}
