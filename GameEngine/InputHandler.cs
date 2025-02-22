﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace NinjaPacman
{

    //Handles all User Inputs
    public class InputHandler
    {
        protected KeyboardState currentKeyboardState;
        protected KeyboardState previousKeyboardState;

        protected MouseState currentMouseState;
        protected MouseState previousMouseState;
        protected Matrix translation;
        public InputHandler()
        {
            previousKeyboardState = Keyboard.GetState();
            previousMouseState = Mouse.GetState();
            translation = Matrix.CreateTranslation(0f, 0f, 0f);
        }


        public bool IsKeyPressed(Keys pressedKey)
        {
            return currentKeyboardState.IsKeyDown(pressedKey) && previousKeyboardState.IsKeyUp(pressedKey);
        }
        public void Update()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }
        public bool IsMousePressed(bool isLeft)
        {

            if (isLeft == true)
            {
                return (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released);
            }
            else
            {
                return (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released);
            }
        }
        public bool IsKeyHeld(Keys pressedKey)
        {
            
            return (currentKeyboardState.IsKeyDown(pressedKey) && previousKeyboardState.IsKeyDown(pressedKey));
        }
        public bool IsMouseHeld(bool isLeft)
        {
            if (isLeft == true)
            {
                return (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Pressed);
            }
            else
            {
                return (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Pressed);
            }
        }
        public Rectangle GetMouseRectangle()
        {
            currentMouseState = Mouse.GetState();
            Vector2 transformedMousePos = Vector2.Transform(new Vector2(currentMouseState.X, currentMouseState.Y), Matrix.Invert(translation));
            return new Rectangle((int)transformedMousePos.X, (int)transformedMousePos.Y, 30, 30);
        }
        public void setCameraTranslation(Matrix translation)
        {
            this.translation = translation;
        }


    }
}
