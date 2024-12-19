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
        Player playerSprite;
        UIButtons normalSprite;
        FollowCamera camera = new FollowCamera(Vector2.Zero);
        GraphicsDeviceManager _graphics;
        SongManager songManager;
        SoundEffectManager soundManager;
        
        public TestScene(GraphicsDeviceManager _graphics)
        {
            this._graphics = _graphics;
        }
        public void Initialize(Game game)
        {
            inputHandler = new InputHandler();
            songManager = new SongManager(100);
            soundManager = new SoundEffectManager();
            soundManager.AddSound("testEffect", "effect", game);
            songManager.AddSong("testSong", "song", game);
            songManager.setCurrentSong("testSong");
        }
        public void Update(GameTime gameTime)
        {
            inputHandler.Update();
            playerSprite.Update(gameTime);
            normalSprite.Update(gameTime);
            camera.Follow(playerSprite, new Vector2(_graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight));
            inputHandler.setCameraTranslation(camera.translation);
            if(normalSprite.isPressed(true))
            {
                songManager.playCurrentSong(true);
            }
            if(inputHandler.IsKeyPressed(Keys.N))
            {
                songManager.pauseCurrentSong();
            }
            if (inputHandler.IsKeyPressed(Keys.M))
            {
                songManager.resumeCurrentSong();
            }



        }
        public void Load(Game game)
        {
            playerSprite = new Player(game.Content.Load<Texture2D>("Image1"), new Vector2(400,200), new Vector2(50,50), inputHandler);
            normalSprite = new UIButtons(game.Content.Load<Texture2D>("Image1"), new Vector2(400, 400), new Vector2(50, 50),inputHandler);
            

        }
        public void Draw(SpriteBatch batch)
        {
            
            batch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: camera.translation);
            playerSprite.Draw(batch);
            normalSprite.Draw(batch);
            batch.End();
        }
    }
}
