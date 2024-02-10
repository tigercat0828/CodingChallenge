using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace TopDownShooter {
    public class Zombie : Sprite {
        public Zombie(Texture2D texture, Vector2 position) : base(texture, position) {
            Speed = 100;
        }
        public void Update(Player player) {
            var toPlayer = player.Position - this.Position;
            Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);
            if(toPlayer.Length() > 4) {
                var dir = Vector2.Normalize(toPlayer);
                Position += dir * Speed * Globals.DeltaTime;
            }
        }
    }
}
