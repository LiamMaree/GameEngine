using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class UIButtons : Sprites
    {
        InputHandler inputHandeler;
        public UIButtons(Texture2D texture, Vector2 position, Vector2 size, InputHandler inputHandeler) : base(texture, position, size)
        {
            this.inputHandeler = inputHandeler;
        }
        public bool isPressed(bool isLeft)
        {
            Rectangle mouseRect =  inputHandeler.GetMouseRectangle();
            if(mouseRect.Intersects(destRect))
            {
                if(inputHandeler.IsMousePressed(isLeft))
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
