using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    //Handles all User Inputs
    internal class InputHandler
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private MouseState currentMouseState;
        private MouseState previousMouseState;
        public InputHandler()
        {
            previousKeyboardState = Keyboard.GetState();
            previousMouseState = Mouse.GetState();
        }
        
        public bool isKeyPressed(Keys pressedKey)
        {
            bool temp = false;
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(pressedKey) && previousKeyboardState.IsKeyUp(pressedKey))
            {
                temp = true;
            }
            previousKeyboardState = currentKeyboardState;
            return temp;
        }
        public bool isMousePressed(bool isLeft)
        {
            bool temp = false;
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                temp = true;
            }
            previousMouseState = currentMouseState;
            return temp;
        }
        public bool isKeyHeld(Keys pressedKey)
        {
            bool temp;
            
            if (Keyboard.GetState().IsKeyDown(pressedKey))
            {
                temp = true;
            }
            else
            {
                temp = false;
            }
            return temp;
        }

        

    }
}
