using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NinjaPacman
{
    public class AnimatedSprite : Sprites
    {
        protected AnimationManager animationManager;
        
        public AnimatedSprite(String name, AnimationManager animationManager, Vector2 position, Vector2 size, float collisionSize) : base(name, null, position, size,collisionSize)
        {
            this.animationManager = animationManager;
            
        }
        public override void Update(GameTime gameTime)
        {
            animationManager.Update(gameTime);

        }
        public override void Load(Game game)
        {
            animationManager.Load(game);
        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(animationManager.getSpriteSheet(), destRect, animationManager.getCurrentFrame(), Color.White);

        }
    }
}
