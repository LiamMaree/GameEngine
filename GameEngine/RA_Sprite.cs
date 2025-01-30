using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NinjaPacman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class RA_Sprite : AnimatedSprite
    {
        public float rotation { get; set; }
        public RA_Sprite(String name, AnimationManager animationManager, Vector2 position, Vector2 size, float rotation) : base(name, animationManager, position, size)
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
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(animationManager.getSpriteSheet(),
                destRect,
                animationManager.getCurrentFrame(),
                Color.White,
                (float)(rotation * (Math.PI / 180)),
                new Vector2(animationManager.getCurrentFrame().Width / 2, animationManager.getCurrentFrame().Height / 2),
                SpriteEffects.None,
                0.0f);

        }
    }
}

