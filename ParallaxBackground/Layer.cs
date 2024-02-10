using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxBackground {
    public class Layer {
        private readonly Texture2D texture;
        public Vector2 position;
        public Vector2 position2;
        public readonly float depth;
        public readonly float moveScale;

        public Layer(Texture2D texture,  float depth, float moveScale) {
            this.texture = texture;
            this.depth = depth;
            this.moveScale = moveScale;
            position = Vector2.Zero;
            position2 = Vector2.Zero;
        }
        public void Update(float movement) {
            position.X += movement * moveScale * Globals.DeltaTime;
            position.X%= texture.Width;

            if(position.X >= 0) {
                position2.X = position.X - texture.Width;
            }
            else {
                position2.X = position.X + texture.Width;
            }
        }
        public void Draw() {
            Globals.SpriteBatch.Draw(texture: texture,
                                     position: position,
                                     sourceRectangle: null,
                                     color: Color.White,
                                     rotation: 0,
                                     origin: Vector2.Zero,
                                     scale: Vector2.One,
                                     effects: SpriteEffects.None,
                                     layerDepth: depth);

            Globals.SpriteBatch.Draw(texture: texture,
                         position: position2,
                         sourceRectangle: null,
                         color: Color.White,
                         rotation: 0,
                         origin: Vector2.Zero,
                         scale: Vector2.One,
                         effects: SpriteEffects.None,
                         layerDepth: depth);
        }
    }
}
