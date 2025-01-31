using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NinjaPacman
{
    public class Sprites
    {
        public String textureName { get; set; }
        protected Texture2D texture;
        public Vector2 position;
        public Vector2 size { get; set; }
        public String name;
        public float collisionSize;
        
        

        //Creates Rectangle of Sprite and updates it to the sprites current position
        public virtual Rectangle destRect
        {
            get
            {
                return new Rectangle((int)(position.X - (size.X / 2)), (int)(position.Y - (size.Y / 2)), (int)size.X, (int)size.Y);
            }
        }
        public virtual Rectangle colRect
        {
            get
            {
                return new Rectangle((int)(position.X - ((size.X / 2) * collisionSize)), (int)(position.Y - ((size.Y / 2) * collisionSize)), (int)(size.X * collisionSize), (int)(size.Y * collisionSize));
            }
        }
        public Sprites(String name, String textureName, Vector2 position, Vector2 size, float collisionSize)
        {
            this.collisionSize = collisionSize;
            this.textureName = textureName;
            this.position = position;
            this.size = size;
            this.name = name;
        }
        public virtual void Initialize(Game game)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Load(Game game)
        {
            texture = game.Content.Load<Texture2D>(textureName);
            
        }
        public virtual void Draw(SpriteBatch batch)
        {

            
            batch.Draw(texture, destRect, Color.White);
            
        }



    }
}
