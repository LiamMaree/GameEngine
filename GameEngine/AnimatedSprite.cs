using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameEngine
{
    public class AnimatedSprite : Sprites
    {
        AnimationManager animationManager;
        public AnimatedSprite(String name, AnimationManager animationManager, Vector2 position, Vector2 size) : base(name, null, position, size)
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
