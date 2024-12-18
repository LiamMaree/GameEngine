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

        InputHandler inputHandler;
        public EmptyScene(InputHandler inputHandler)
        {
            this.inputHandler = inputHandler;
        }

        public void Update(GameTime gameTime)
        {
            
        }
        public void Load(Game1 game)
        {
            
        }
        public void Draw(SpriteBatch batch)
        {
            
        }
    }
}
