using Microsoft.Xna.Framework;
using System;


namespace NinjaPacman
{
    public class UIButtons : Sprites
    {
        InputHandler inputHandeler;

        public UIButtons(String name, String textureName, Vector2 position, Vector2 size, InputHandler inputHandeler, float collisionSize) : base(name, textureName, position, size,collisionSize)
        {
            this.inputHandeler = inputHandeler;

        }
        public bool isPressed(bool isLeft)
        {
            Rectangle mouseRect = inputHandeler.GetMouseRectangle();
            if (mouseRect.Intersects(destRect))
            {
                if (inputHandeler.IsMousePressed(isLeft))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
