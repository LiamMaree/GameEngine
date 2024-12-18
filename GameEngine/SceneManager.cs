using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SceneManager
    {
        Dictionary<String, IScenes> sManager;
        String currentScene;
        public SceneManager()
        {
            sManager = new Dictionary<String, IScenes>();
        }
        public void setCurrentScene(String currentScene)
        {
            this.currentScene = currentScene;
        }
        public void Update()
        {
            sManager[currentScene].Update();
        }
        public void Load(Game game)
        {
            sManager[currentScene].Load(game);
        }
        public void Draw(SpriteBatch batch)
        {
            sManager[currentScene].Draw(batch);
        }
        public void AddScene(String sceneName,IScenes scene)
        {
            sManager.Add(sceneName, scene);
        }
        public void RemoveScene(String sceneName)
        {
            sManager.Remove(sceneName);
        }
    }
}
