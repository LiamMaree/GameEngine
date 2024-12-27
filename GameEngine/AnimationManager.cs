using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace NinjaPacman
{
    public class AnimationManager
    {
        
        float counter = 0;
        int activeFrame = 0;
        String spriteSheetName;
        Texture2D spriteSheet;
        List<Rectangle> allFrames;
        Dictionary<String, Rectangle[]> Animations;
        String currentAnimation;
        Rectangle currentFrame;
        float frameTime;
        public bool tempAnimationPlaying { get; set; }
        String previousAnimation;
        int frameRate;
        int previousFrameRate;
        
        public AnimationManager(int frameRate, String spriteSheetName, int numOfRows, int numOfColumns, Point frameSize, Point offset)
        {
            allFrames = new List<Rectangle>();
            Animations = new Dictionary<string, Rectangle[]>();
            frameTime = 1f / frameRate;
            this.frameRate = frameRate;
            this.spriteSheetName = spriteSheetName;
            for (int j = 0; j < numOfRows; j++) // Outer loop for rows
            {
                for (int i = 0; i < numOfColumns; i++) // Inner loop for columns
                {
                    allFrames.Add(new Rectangle(
                        (int)(i * (frameSize.X + offset.X)), // Calculate based on column index
                        (int)(j * (frameSize.Y + offset.Y)), // Calculate based on row index
                        (int)frameSize.X,
                        (int)frameSize.Y));
                }
            }
            tempAnimationPlaying = false;
        }
        public void AddAnimation(String name, int startFrame, int endFrame)
        {
            Animations.Add(name, allFrames.GetRange(startFrame, endFrame - startFrame + 1).ToArray());
        }
        public void PlayAnimation(String name,bool onceOFF,int frameRate)
        {
            if(onceOFF == true)
            {
                previousAnimation = currentAnimation;
                tempAnimationPlaying = true;
            }
            if (currentAnimation != name)
            {
                currentAnimation = name;
                activeFrame = 0;
            }
            if(frameRate == 0)
            {
                frameTime = 1f / this.frameRate;
            }
            else
            {
                frameTime = 1f / frameRate;
            }
            previousFrameRate = (int)(1f / frameTime);
        }
        public int GetActiveFrame()
        {
            return activeFrame;
        }
        public void Load(Game game)
        {
            spriteSheet = game.Content.Load<Texture2D>(spriteSheetName);
        }
        public void Update(GameTime gameTime)
        {
            // Add elapsed time to the timer
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Check if it's time to advance the frame
            if (counter >= frameTime)
            {
                counter -= counter; // Subtract frameTime to handle any overshoot
                activeFrame++;

                // Loop back to the first frame if we've reached the end
                if (activeFrame >= Animations[currentAnimation].Length)
                {
                    activeFrame = 0;
                    if(tempAnimationPlaying == true)
                    {
                        PlayAnimation(previousAnimation, false, previousFrameRate);
                        tempAnimationPlaying = false;
                    }
                }

                // Update the current frame
                currentFrame = Animations[currentAnimation][activeFrame];
            }
        }
        
        public Rectangle getCurrentFrame()
        {
            return currentFrame;
        }
        public Texture2D getSpriteSheet()
        {
            return spriteSheet;
        }
    }
}
