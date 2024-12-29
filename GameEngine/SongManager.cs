using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace NinjaPacman
{
    public class SongManager
    {
        protected Dictionary<String, Song> songManager;
        protected String currentSong;
        protected int volume;


        public SongManager(int volume)
        {
            songManager = new Dictionary<String, Song>();
            this.volume = volume;
            MediaPlayer.Volume = volume;
        }
        public void SetCurrentSong(String currentSong)
        {
            this.currentSong = currentSong;
        }
        public void SetVolume(int volume)
        {
            this.volume = volume;
        }
        public void AddSong(String songName, String songFileName, Game game)
        {
            songManager.Add(songName, game.Content.Load<Song>(songFileName));
        }
        public void RemoveScene(String songName)
        {
            songManager.Remove(songName);
        }
        public void PlayCurrentSong(bool repeating)
        {
            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(songManager[currentSong]);  // Start playback
                if (repeating == true)
                {
                    MediaPlayer.IsRepeating = true;     // Enable looping
                }
            }

        }
        public void PauseCurrentSong()
        {
            if (MediaPlayer.State == MediaState.Playing)  // Only pause if playing
            {
                MediaPlayer.Pause();
            }
        }
        public void ResumeCurrentSong()
        {

            if (MediaPlayer.State == MediaState.Paused)  // Only resume if paused
            {
                MediaPlayer.Resume();
            }
        }
        public void StopCurrentSong()
        {
            MediaPlayer.Stop();  // Stops the song and resets the state
        }
    }
}
