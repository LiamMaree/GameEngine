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
        AnimationManager animationManager;
        Rectangle bounds;
        Rectangle[] collisionLayer;
        public Player(String name,AnimationManager animationManager, Vector2 position, Vector2 size,InputHandler inputHandler,Rectangle bounds,Rectangle[] collisionLayer) : base(name,null,position,size)
        {
            this.animationManager = animationManager;
            this.inputHandler = inputHandler;
            this.animationManager.PlayAnimation("Idle");
            this.bounds = bounds;
            this.collisionLayer = collisionLayer;
        }

        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);

            // Predict the new position
            Vector2 newPosition = position;
            if (inputHandler.IsKeyHeld(Keys.D) && position.X < bounds.Right)
            {
                newPosition = new Vector2(position.X + 10, position.Y);
                animationManager.PlayAnimation("Walking Right");
            }
            else if (inputHandler.IsKeyHeld(Keys.A) && position.X > bounds.Left)
            {
                newPosition = new Vector2(position.X - 10, position.Y);
                animationManager.PlayAnimation("Walking Left");
            }
            else if (inputHandler.IsKeyHeld(Keys.W) && position.Y > bounds.Top)
            {
                newPosition = new Vector2(position.X, position.Y - 10);
                animationManager.PlayAnimation("Walking Vertically");
            }
            else if (inputHandler.IsKeyHeld(Keys.S) && position.Y < bounds.Bottom)
            {
                newPosition = new Vector2(position.X, position.Y + 10);
                animationManager.PlayAnimation("Walking Vertically");
            }
            else
            {
                animationManager.PlayAnimation("Idle");
            }

            // Create a rectangle representing the player's bounding box at the new position
            Rectangle playerRectangle = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                (int)size.X,  // Replace with the player's actual width
                (int)size.Y  // Replace with the player's actual height
            );

            // Check for collisions
            bool collision = false;
            foreach (Rectangle rect in collisionLayer)
            {
                if (playerRectangle.Intersects(rect))
                {
                    collision = true;
                    break;
                }
            }

            // Apply movement only if there's no collision
            if (!collision)
            {
                position = newPosition;
            }
        }
        public override void Load(Game game)
        {
            animationManager.Load(game);
            
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(animationManager.getSpriteSheet(), destRect,animationManager.getCurrentFrame() ,Color.White);

        }
    }
}
