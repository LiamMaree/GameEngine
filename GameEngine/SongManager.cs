using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class SongManager
    {
        Dictionary<String, Song> songManager;
        String currentSong;
        int volume;
        
        
        public SongManager(int volume)
        {
            songManager = new Dictionary<String, Song>();
            this.volume = volume;
            MediaPlayer.Volume = volume;
        }
        public void setCurrentSong(String currentSound)
        {
            this.currentSong = currentSound;
        }
        public void setVolume(int volume)
        {
            this.volume = volume;
        }
        public void AddSong(String soundName, String songFileName, Game game)
        {
            songManager.Add(soundName, game.Content.Load<Song>(songFileName));
        }
        public void RemoveScene(String songName)
        {
            songManager.Remove(songName);
        }
        public void playCurrentSong(bool repeating)
        {
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(songManager[currentSong]);  // Start playback
                if(repeating == true)
                {
                    MediaPlayer.IsRepeating = true;     // Enable looping
                }
            }
            
        }
        public void pauseCurrentSong()
        {           
            if (MediaPlayer.State == MediaState.Playing)  // Only pause if playing
            {
                MediaPlayer.Pause();
            }
        }
        public void resumeCurrentSong()
        {
            
            if (MediaPlayer.State == MediaState.Paused)  // Only resume if paused
            {
                MediaPlayer.Resume();
            }
        }
        public void stopCurrentSong()
        {
            MediaPlayer.Stop();  // Stops the song and resets the state
        }
    }
}
