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

        public TestScene(InputHandler inputHandler, GraphicsDeviceManager _graphics)
        {
            this.inputHandler = inputHandler;
            this._graphics = _graphics;
        }
        
        public void Update(GameTime gameTime)
        {
            playerSprite.Update(gameTime);
            normalSprite.Update(gameTime);
            camera.Follow(playerSprite, new Vector2(_graphics.PreferredBackBufferWidth,_graphics.PreferredBackBufferHeight));
            inputHandler.setCameraTranslation(camera.translation);
            if(normalSprite.isPressed(true))
            {
                Debug.WriteLine("clicked");
            }
            
        }
        public void Load(Game game)
        {
            playerSprite = new Player(game.Content.Load<Texture2D>("Image1"), new Vector2(400,200), new Vector2(50,50), inputHandler);
            normalSprite = new UIButtons(game.Content.Load<Texture2D>("Image1"), new Vector2(400, 400), new Vector2(50, 50),inputHandler);
            

        }
        public void Draw(SpriteBatch batch)
        {
            
            batch.Begin(samplerState: SamplerState.PointClamp,transformMatrix: camera.translation);
            playerSprite.Draw(batch);
            normalSprite.Draw(batch);
            batch.End();
        }
    }
}
