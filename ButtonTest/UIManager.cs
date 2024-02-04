using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace ButtonTest {
    public class UIManager {
        private Texture2D DefaultButtonTexture { get; }
        private SpriteFont Font { get; }
        private readonly List<Button> _buttons = new();
        public int Counter { get; set; }
        public UIManager() {
            DefaultButtonTexture = Globals.Content.Load<Texture2D>("button");
            Font = Globals.Content.Load<SpriteFont>("font");
        }
        public Button AddButton(Vector2 position) {
            Button btn = new(DefaultButtonTexture, position);
            _buttons.Add(btn);
            return btn;
        }
        public void Update() {
            foreach (Button button in _buttons) { 
                button.Update();
            }
        }
        public void Draw() {
            foreach (Button button in _buttons) {
                button.Draw();
            }
            Globals.SpriteBatch.DrawString(Font, Counter.ToString(), new(10, 10), Color.Black);
        }
        
    }
}