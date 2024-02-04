using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace SpriteSheetAnimation {
    public class Coin {
        private static Texture2D texture;
        public Vector2 position;
        public readonly Animation animation;
        public Coin( Vector2 position)
        {
            texture ??= Globals.Content.Load<Texture2D>("coin");
            animation = new(texture, 6,1, 0.1f);
            this.position = position;
        }
        public void Update() {
            animation.Update();
        }
        public void Draw() {
            animation.Draw(position);
        }
    }
}
