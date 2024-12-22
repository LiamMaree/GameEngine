using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        AnimationManager animationManager;
        TileMap map;
        
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
            animationManager = new AnimationManager(10, "StickMan", 1, 7, new Point(8, 8), new Point(0, 0));
            map = new TileMap("BoatTestTilemap", 1, 6, new Point(8, 8), new Point(0, 0),64);
            map.AddLayer("../../../Content/TestLayer1.csv");
            map.AddLayer("../../../Content/TestLayer2.csv");
            map.AddCollisionLayer("../../../Content/TestLayer2.csv",-1);
            soundManager.AddSound("testEffect", "effect", game);
            songManager.AddSong("testSong", "song", game);
            songManager.SetCurrentSong("testSong");
            animationManager.AddAnimation("Idle", 0, 0);
            animationManager.AddAnimation("Walking Right", 1, 2);
            animationManager.AddAnimation("Walking Left", 3, 4);
            animationManager.AddAnimation("Walking Vertically", 5, 6);
            spriteManager.AddSprite(new Player("Player",animationManager, new Vector2(500, 600), new Vector2(64, 64), inputHandler,map.GetTileMapBounds(),map.getCollisionLayer()));
            spriteManager.AddSprite(new UIButtons("button", "Image1", new Vector2(400, 400), new Vector2(50, 50), inputHandler));
            camera.setBounds(map.GetTileMapBounds());
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
            map.Load(game);

        }
        public void Draw(SpriteBatch batch)
        {
            
            batch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: camera.translation);
            map.Draw(batch);
            spriteManager.Draw(batch);
            batch.End();
        }
    }
}
