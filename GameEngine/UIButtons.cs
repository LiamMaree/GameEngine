using Microsoft.Xna.Framework;
using System;


namespace GameEngine
{
    public class UIButtons : Sprites
    {
        InputHandler inputHandeler;

        public UIButtons(String name, String textureName, Vector2 position, Vector2 size, InputHandler inputHandeler) : base(name, textureName, position, size)
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
