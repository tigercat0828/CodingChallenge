using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace SpriteSheetAnimation {
    public class Animation {
        private readonly Texture2D texture;
        private readonly List<Rectangle> rectangles = new();
        private readonly int frameNumX;
        private int frameIndex;
        private readonly float frameTime;
        private float nextFrameTimer;
        private bool active =true;
        public Animation (Texture2D texture, int frameNumX,int frameNumY, float frameTime, int row =1) {
            this.texture = texture;
            this.frameTime = frameTime;
            this.frameNumX = frameNumX;
            nextFrameTimer = frameTime;
            var frameWidth = texture.Width / frameNumX;
            var frameHeight = texture.Height / frameNumY;

            for (int i = 0; i < frameNumX; i++) {
                rectangles.Add(new Rectangle(i * frameWidth, (row-1)* frameHeight, frameWidth, frameHeight));
            }
        }
        public void Start() {
            active = true;
        }
        public void Stop() {
            active = false;
        }
        public void Reset() {
            frameIndex = 0;
            nextFrameTimer = frameTime;
        }

        public void Update() {
            if (!active) return;
            nextFrameTimer -= Globals.DeltaTime;
            if(nextFrameTimer < 0) {
                nextFrameTimer = frameTime;
                frameIndex = (frameIndex + 1) % frameNumX;
            }
        }
        public void Draw(Vector2 position) {
            Globals.SpriteBatch.Draw(
                texture: texture,
                position: position,
                sourceRectangle: rectangles[frameIndex],
                color: Color.White,
                rotation: 0,
                origin: Vector2.Zero,
                scale: Vector2.One,
                effects: SpriteEffects.None,
                layerDepth: 1);
        }

    }


}
