using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SoundEffectManager
    {
        Dictionary<String, SoundEffect> soundManager;
        
        public SoundEffectManager()
        {
            soundManager = new Dictionary<String, SoundEffect>();
        }
        
        public void AddSound(String soundName, String soundFileName, Game game)
        {
            soundManager.Add(soundName, game.Content.Load<SoundEffect>(soundFileName));
        }
        public void RemoveSound(String soundName)
        {
            soundManager.Remove(soundName);
        }
        public void playSound(String soundName)
        {
            soundManager[soundName].Play();
        }
        public SoundEffectInstance getSoundInstance(String soundName)
        {
            return soundManager[soundName].CreateInstance();
        }
        
    }
}
