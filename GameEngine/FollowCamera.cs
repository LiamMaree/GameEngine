using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace NinjaPacman
{
    public class FollowCamera
    {
        public Vector2 position;
        public Matrix translation;
        protected Rectangle bounds;
        public FollowCamera(Vector2 position)
        {
            this.position = position;
            
            
        }
        public void setBounds(Rectangle bounds)
        {
            this.bounds = bounds;
        }
        public void Follow(Sprites target, Vector2 screenSize)
        {


            position = target.position - (screenSize / 2);  // Center the player

            if(!bounds.IsEmpty)
            {
                position.X = MathHelper.Clamp(position.X, bounds.Left, bounds.Right - screenSize.X);
                position.Y = MathHelper.Clamp(position.Y, bounds.Top, bounds.Bottom - screenSize.Y);
            }

            // Create the translation matrix to move the world relative to the camera
            translation = Matrix.CreateTranslation(-position.X, -position.Y, 0f);
        }

    }
}
