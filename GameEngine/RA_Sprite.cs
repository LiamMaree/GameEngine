using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NinjaPacman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace GameEngine
{
    public class RA_Sprite : AnimatedSprite
    {
        public float rotation { get; set; }
        protected Texture2D collisionTexture;
        
        public override Rectangle colRect
        {
            get
            {
                return new Rectangle((int)(position.X - ((animationManager.getCurrentFrame().Width * size.X / 2) * collisionSize)), (int)(position.Y - ((animationManager.getCurrentFrame().Height * size.Y / 2) * collisionSize)), (int)((animationManager.getCurrentFrame().Width * size.X) * collisionSize), (int)((animationManager.getCurrentFrame().Height * size.Y) * collisionSize));
            }
        }
        public RA_Sprite(String name, AnimationManager animationManager, Vector2 position, Vector2 size, float rotation,float collisionSize) : base(name, animationManager, position, size,collisionSize)
        {
            this.rotation = rotation;
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            rotation %= 360;
            if (rotation < 0)
            {
                rotation += 360;
            }
        }
        public override void Load(Game game)
        {
            base.Load(game);
            collisionTexture = game.Content.Load<Texture2D>("collisionCheck");
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(collisionTexture, colRect, Color.Red);
            batch.Draw(
            animationManager.getSpriteSheet(), // Texture
            position,                          // Position (center of the sprite)
            animationManager.getCurrentFrame(),                      // Source rectangle (current frame)
            Color.White,                       // Color
            (float)(rotation * (Math.PI / 180)), // Rotation (in radians)
            new Vector2(animationManager.getCurrentFrame().Width / 2, animationManager.getCurrentFrame().Height / 2), // Origin (center of the frame)
            size,                             // Scale
            SpriteEffects.None,                // Sprite effects
            0.0f                               // Layer depth
    );

        }
    }
}

