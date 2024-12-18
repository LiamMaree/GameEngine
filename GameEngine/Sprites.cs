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
        private Texture2D texture;
        Vector2 position;
        int scale;

        //Creates Rectangle of Sprite and updates it to the sprites current position
        Rectangle destRect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, 50 * scale, 50 * scale);
            }
        }
        public Sprites(Texture2D texture,Vector2 position,int scale)
        {
            this.texture = texture;
            this.position = position;
            this.scale = scale;
        }

        public void Update()
        {

        }
        public void Load()
        {
            
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Begin();
            batch.Draw(texture, destRect, Color.White);
            batch.End();
        }


    }     
}
