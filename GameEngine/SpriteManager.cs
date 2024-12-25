using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NinjaPacman
{
    public class SpriteManager
    {
        public List<Sprites> spriteList;
        protected List<Sprites> spritesToDelete;
        protected List<Sprites> spritesToAdd;
        protected Game game;
        public SpriteManager(Game game)
        {
            this.game = game;
            spriteList = new List<Sprites>();
            spritesToDelete = new List<Sprites>();
            spritesToAdd = new List<Sprites>();
        }
        public void AddSprite(Sprites sprite)
        {
            spriteList.Add(sprite);
        }
        public void AddSpriteRunTime(Sprites sprite)
        {
            spritesToAdd.Add(sprite);
        }
        public void DeleteSprite(Sprites sprite)
        {
            spritesToDelete.Add(sprite);
        }
        public void DeleteSpriteByName(String name)
        {
            spriteList.Remove(GetSpriteByName(name));

        }
        public Sprites GetSprite(Func<Sprites, bool> keySelector)
        {
            return spriteList.FirstOrDefault(keySelector);
        }
        public Sprites GetSpriteByName(string name)
        {
            return spriteList.FirstOrDefault(sprite => sprite.name == name);
        }

        public virtual void OrderSpritesASC(Func<Sprites, float> keySelector)
        {

            spriteList = spriteList.OrderBy(keySelector).ToList();
        }
        public virtual void OrderSpritesDESC(Func<Sprites, float> keySelector)
        {

            spriteList = spriteList.OrderByDescending(keySelector).ToList();
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprites sprite in spriteList)
            {
                sprite.Update(gameTime);
                
            }
            
            foreach (Sprites sprite in spritesToAdd)
            {
                spriteList.Add(sprite);
                Load(game);

            }
            spritesToAdd.Clear();
            foreach (Sprites sprite in spritesToDelete)
            {
                spriteList.Remove(sprite);
            }
            spritesToDelete.Clear();
        }
        public void Load(Game game)
        {
            
            foreach (Sprites sprite in spriteList)
            {
                sprite.Load(game);
            }
        }
        public void Draw(SpriteBatch batch)
        {
            foreach (Sprites sprite in spriteList)
            {
                sprite.Draw(batch);
            }
        }

    }
}
