using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class SceneManager
    {
        Dictionary<String, Scenes> Smanager;
        String currentScene;
        public SceneManager()
        {
            
        }
        public void setCurrentScene(String currentScene)
        {
            this.currentScene = currentScene;
        }
        public void Update()
        {
            Smanager[currentScene].Update();
        }
        public void Load()
        {
            Smanager[currentScene].Load();
        }
        public void Draw(SpriteBatch batch)
        {
            Smanager[currentScene].Draw(batch);
        }
        public void AddScene(String sceneName,Scenes scene)
        {
            Smanager.Add(sceneName, scene);
        }
        public void RemoveScene(String sceneName)
        {
            Smanager.Remove(sceneName);
        }
    }
}
