using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine
{
    public class Sprites
    {
        protected Texture2D texture;
        public Vector2 position { get; set; }
        public Vector2 size { get; set; }

        //Creates Rectangle of Sprite and updates it to the sprites current position
        public Rectangle destRect
        {
            get
            {
                return new Rectangle((int)(position.X - (size.X/2)), (int)(position.Y - (size.Y / 2)),(int)size.X, (int)size.Y);
            }
        }
        public Sprites(Texture2D texture,Vector2 position,Vector2 size)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }
        public void Load()
        {
            
        }
        public void Draw(SpriteBatch batch)
        {

            
            batch.Draw(texture, destRect, Color.White);
            
        }

        
       
    }     
}
