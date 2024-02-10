using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace TopDownShooter {
    public static class InputManager {
        static MouseState lastMouseState;
        static Vector2 direction;
        public static Vector2 Direction => direction;
        public static Vector2 MousePosition => Mouse.GetState().Position.ToVector2();
        public static bool MouseClicked;
        public static void Update() {
            var keyboardState = Keyboard.GetState();

            direction = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W)) direction.Y--;
            if (keyboardState.IsKeyDown(Keys.S)) direction.Y++;
            if (keyboardState.IsKeyDown(Keys.A)) direction.X--;
            if (keyboardState.IsKeyDown(Keys.D)) direction.X++;

            MouseClicked = (Mouse.GetState().LeftButton == ButtonState.Pressed) && (lastMouseState.LeftButton == ButtonState.Released);

            lastMouseState = Mouse.GetState();

        }
    }
}
