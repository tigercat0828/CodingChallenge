
using System;


namespace ButtonTest {
    public class Button {
        private readonly Texture2D texture;
        public readonly Rectangle rect;
        private Vector2 position;
        private Color shade = Color.White;


        public Button(Texture2D texture, Vector2 position) {
            this.texture = texture;
            this.position = position;
            rect = new((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Update() {
            if (Globals.MouseCursor.Intersects(rect)) {
                shade = Color.DarkGray;
                if (Globals.LeftButtonClicked) {
                    Click();
                }
            }
            else {
                shade = Color.White;
            }
        }
        public event EventHandler OnClick;
        private void Click() {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
        public void Draw() {
            Globals.SpriteBatch.Draw(texture, position, shade);
        }
    }
}
