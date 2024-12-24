using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace NinjaPacman
{
    public class Sprites
    {
        public String textureName { get; set; }
        protected Texture2D texture;
        public Vector2 position { get; set; }
        public Vector2 size { get; set; }
        public String name;

        //Creates Rectangle of Sprite and updates it to the sprites current position
        public Rectangle destRect
        {
            get
            {
                return new Rectangle((int)(position.X - (size.X / 2)), (int)(position.Y - (size.Y / 2)), (int)size.X, (int)size.Y);
            }
        }
        public Sprites(String name, String textureName, Vector2 position, Vector2 size)
        {
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
