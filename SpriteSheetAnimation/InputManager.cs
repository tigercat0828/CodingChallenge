﻿

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Reflection.Metadata.Ecma335;

namespace SpriteSheetAnimation {
    public static  class InputManager {
        private static Vector2 direction;
        public static Vector2 Direcion => direction;
        public static bool IsMoving => direction != Vector2.Zero;

        public static void Update() {
            direction = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if(keyboardState.GetPressedKeyCount() > 0) {
                if (keyboardState.IsKeyDown(Keys.A)) direction.X--;
                if (keyboardState.IsKeyDown(Keys.D)) direction.X++;
                if (keyboardState.IsKeyDown(Keys.W)) direction.Y--;
                if (keyboardState.IsKeyDown(Keys.S)) direction.Y++;
            }
        }
    }
}
