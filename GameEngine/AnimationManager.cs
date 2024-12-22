using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace GameEngine
{
    public class AnimationManager
    {
        int frameRate;
        int counter = 0;
        int activeFrame = 0;
        String spriteSheetName;
        Texture2D spriteSheet;
        List<Rectangle> allFrames;
        Dictionary<String, Rectangle[]> Animations;
        String currentAnimation;
        Rectangle currentFrame;
        public AnimationManager(int frameRate, String spriteSheetName, int numOfRows, int numOfColumns, Point frameSize, Point offset)
        {
            allFrames = new List<Rectangle>();
            Animations = new Dictionary<string, Rectangle[]>();
            this.frameRate = frameRate;
            this.spriteSheetName = spriteSheetName;
            for (int i = 0; i < numOfColumns; i++)
            {
                for (int j = 0; j < numOfRows; j++)
                {
                    allFrames.Add(new Rectangle(
                        (int)(i * (frameSize.X + offset.X)), // Calculate based on column index
                        (int)(j * (frameSize.Y + offset.Y)), // Calculate based on row index
                        (int)frameSize.X,
                        (int)frameSize.Y));
                }
            }
        }
        public void AddAnimation(String name, int startFrame, int endFrame)
        {
            Animations.Add(name, allFrames.GetRange(startFrame, endFrame - startFrame + 1).ToArray());
        }
        public void PlayAnimation(String name)
        {
            if (currentAnimation != name)
            {
                currentAnimation = name;
                activeFrame = 0;
            }

        }
        public void Load(Game game)
        {
            spriteSheet = game.Content.Load<Texture2D>(spriteSheetName);
        }
        public void Update(GameTime gameTime)
        {
            counter++;
            if (counter >= frameRate)
            {
                counter = 0;
                currentFrame = Animations[currentAnimation][activeFrame];
                activeFrame++;
                if (activeFrame >= Animations[currentAnimation].Length)
                {
                    activeFrame = 0;
                }
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
