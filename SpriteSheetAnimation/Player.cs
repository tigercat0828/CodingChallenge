

using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace SpriteSheetAnimation {
    public class Player {
        private Vector2 position = new(100, 100);
        private readonly float speed = 200f;
        private readonly AnimationManager animations = new();
        public Player()
        {
            var playerTexture = Globals.Content.Load<Texture2D>("hero");
            animations.AddAnimation(new Vector2(0, 1), new(playerTexture, 8, 8, 0.1f, 1));
            animations.AddAnimation(new Vector2(-1, 0), new(playerTexture, 8, 8, 0.1f, 2));
            animations.AddAnimation(new Vector2(1, 0), new(playerTexture, 8, 8, 0.1f, 3));
            animations.AddAnimation(new Vector2(0, -1), new(playerTexture, 8, 8, 0.1f, 4));
            animations.AddAnimation(new Vector2(-1, 1), new(playerTexture, 8, 8, 0.1f, 5));
            animations.AddAnimation(new Vector2(-1, -1), new(playerTexture, 8, 8, 0.1f,6));
            animations.AddAnimation(new Vector2(1, 1), new(playerTexture, 8, 8, 0.1f, 7));
            animations.AddAnimation(new Vector2(1, -1), new(playerTexture, 8, 8, 0.1f, 8));
        }
        public void Update() {
            if (InputManager.IsMoving) {
                position += Vector2.Normalize(InputManager.Direcion) * speed * Globals.DeltaTime;
            }
            animations.Update(InputManager.Direcion);
        }
        public void Draw() {
            animations.Draw(position);
        }
    }
}
