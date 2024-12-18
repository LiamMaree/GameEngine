using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public interface IScenes
    {
        
        public void Update(GameTime gameTime)
        {

        }
        public void Load(Game game)
        {

        }
        public void Draw(SpriteBatch batch)
        {

        }
    }
}
