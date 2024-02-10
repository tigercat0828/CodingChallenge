using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace TopDownShooter {
    public class Sprite {
        protected readonly Texture2D texture;
        protected readonly Vector2 origin;
        public Vector2 Position { get; set; }
        public int Speed { get; set; }
        public float Rotation { get; set; }
        public Sprite(Texture2D texture, Vector2 position) {
            this.texture = texture;
            Position = position;
            Speed = 300;
            origin = new(texture.Width / 2, texture.Height/2);
        }
        public virtual void Draw() {
            Globals.SpriteBatch.Draw(
                texture: texture,
                position: Position,
                sourceRectangle: null,
                color: Color.White,
                rotation: Rotation,
                origin: origin,
                scale: 1,
                effects: SpriteEffects.None,
                layerDepth: 1); 
        }
    }
}
