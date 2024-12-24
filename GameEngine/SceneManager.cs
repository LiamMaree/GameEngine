using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NinjaPacman
{
    public class SceneManager
    {
        protected Dictionary<String, IScenes> sManager;
        protected String currentScene;
        public SceneManager()
        {
            sManager = new Dictionary<String, IScenes>();
        }
        public void SetCurrentScene(String currentScene, Game game)
        {
            this.currentScene = currentScene;
            sManager[currentScene].Initialize(game);
        }
        public void Update(GameTime gameTime)
        {
            sManager[currentScene].Update(gameTime);
        }
        public void Load(Game game)
        {
            sManager[currentScene].Load(game);
        }
        public void Draw(SpriteBatch batch)
        {
            sManager[currentScene].Draw(batch);
        }
        public void AddScene(String sceneName, IScenes scene)
        {
            sManager.Add(sceneName, scene);
        }
        public void RemoveScene(String sceneName)
        {
            sManager.Remove(sceneName);
        }
    }
}
