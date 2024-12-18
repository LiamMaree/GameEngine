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
    internal class EmptyScene: IScenes
    {
        InputHandler inputHandler = new InputHandler();
        public EmptyScene()
        {

        }
        
        public void Update()
        {
            if (inputHandler.IsKeyPressed(Keys.Space))
            {
                Game1.sceneManager.setCurrentScene("TEST");
            }
        }
        public void Load(Game1 game)
        {
            
        }
        public void Draw(SpriteBatch batch)
        {
            
        }
    }
}
