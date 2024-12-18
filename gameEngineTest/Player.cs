using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace gameEngineTest
{
    internal class Player : Sprites
    {
        InputHandler inputHandler;
        public Player(Texture2D texture, Vector2 position, Vector2 size,InputHandler inputHandler) : base(texture,position,size)
        {
            
            this.inputHandler = inputHandler;
        }

        public override void Update(GameTime gameTime)
        {
            if(inputHandler.IsKeyHeld(Keys.D))
            {
                position = new Vector2(position.X + 10,position.Y);
            }
            if (inputHandler.IsKeyHeld(Keys.A))
            {
                position = new Vector2(position.X - 10, position.Y);
            }
            if (inputHandler.IsKeyHeld(Keys.W))
            {
                position = new Vector2(position.X, position.Y - 10);
            }
            if (inputHandler.IsKeyHeld(Keys.S))
            {
                position = new Vector2(position.X, position.Y + 10 );
            }
        }
    }
}
