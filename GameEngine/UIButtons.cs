using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class UIButtons : Sprites
    {
        InputHandler inputHandeler;
        SpriteManager spriteManager;
        public UIButtons(String name,String textureName, Vector2 position, Vector2 size, InputHandler inputHandeler) : base(name,textureName, position, size)
        {
            this.inputHandeler = inputHandeler;
            this.spriteManager = spriteManager;
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
