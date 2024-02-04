using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteSheetAnimation {
    public static class Globals {
        public static float DeltaTime { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static void Update(GameTime gt) {
            DeltaTime = (float)gt.ElapsedGameTime.TotalSeconds;

        }
    }
}
