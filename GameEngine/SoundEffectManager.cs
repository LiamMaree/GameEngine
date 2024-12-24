using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;

namespace NinjaPacman
{
    public class SoundEffectManager
    {
        protected Dictionary<String, SoundEffect> soundManager;

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
        public void PlaySound(String soundName)
        {
            soundManager[soundName].Play();
        }
        public SoundEffectInstance GetSoundInstance(String soundName)
        {
            return soundManager[soundName].CreateInstance();
        }

    }
}
