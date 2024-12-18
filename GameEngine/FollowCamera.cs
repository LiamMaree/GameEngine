using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public  class FollowCamera
    {
        public Vector2 position;
        public Matrix translation;
        public FollowCamera(Vector2 position)
        {
            this.position = position;
        }
        public void Follow(Sprites target,Vector2 screenSize)
        {
            

            // Adjust the camera position to center the target on the screen
            position = target.position - screenSize / 2;

            // Create the translation matrix to move the world relative to the camera
            translation = Matrix.CreateTranslation(-position.X, -position.Y, 0f);
        }
        
    }
}
