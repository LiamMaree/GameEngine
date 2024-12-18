using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{

    //Handles all User Inputs
    public class InputHandler
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private Matrix translation;
        public InputHandler()
        {
            previousKeyboardState = Keyboard.GetState();
            previousMouseState = Mouse.GetState();
            translation = Matrix.CreateTranslation(0f, 0f, 0f);
        }
        
        
        public bool IsKeyPressed(Keys pressedKey)
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
        public bool IsMousePressed(bool isLeft)
        {
            bool temp = false;
            currentMouseState = Mouse.GetState();
            if(isLeft == true)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    temp = true;
                }
            }
            else
            {
                if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
                {
                    temp = true;
                }
            }
            
            previousMouseState = currentMouseState;
            return temp;
        }
        public bool IsKeyHeld(Keys pressedKey)
        {
            bool temp = false;
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(pressedKey) && previousKeyboardState.IsKeyDown(pressedKey))
            {
                temp = true;
            }
            previousKeyboardState = currentKeyboardState;
            return temp;
        }
        public bool IsMouseHeld(bool isLeft)
        {
            bool temp = false;
            currentMouseState = Mouse.GetState();
            if (isLeft == true)
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Pressed)
                {
                    temp = true;
                }
                
            }
            else
            {
                if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Pressed)
                {
                    temp = true;
                }
            }

            previousMouseState = currentMouseState;
            return temp;
        }
        public Rectangle GetMouseRectangle()
        {
            currentMouseState = Mouse.GetState();
            Vector2 transformedMousePos = Vector2.Transform(new Vector2(currentMouseState.X, currentMouseState.Y), Matrix.Invert(translation));
            return new Rectangle((int)transformedMousePos.X,(int)transformedMousePos.Y,30,30);
        }
        public void setCameraTranslation(Matrix translation)
        {
            this.translation = translation;
        }


    }
}
