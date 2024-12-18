using System;
using System.Collections.Generic;
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
        InputHandler inputHandler = new InputHandler();
        public TestScene()
        {

        }
        Sprites circle;
        public void Update()
        {
            if (inputHandler.IsKeyPressed(Keys.Space))
            {
                Game1.sceneManager.setCurrentScene("EMPTY");
            }
        }
        public void Load(Game game)
        {
            circle = new Sprites(game.Content.Load<Texture2D>("Image1"), new Vector2(0, 0), 1);
        }
        public void Draw(SpriteBatch batch)
        {
            circle.Draw(batch);
        }
    }
}
