using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TopDownShooter {
    public class Projectile : Sprite {

        public Vector2 Direction { get; set; }
        public float LifeSpan { get; private set; }
        public Projectile(Texture2D texture, ProjectileData data) : base(texture, data.Position) {
            Speed = data.Speed;
            Rotation = data.Rotation;
            Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
            LifeSpan = data.LifeSpan;
        }
        public void Update() {
            Position += Direction * Speed * Globals.DeltaTime;
            LifeSpan -= Globals.DeltaTime;
        }
    }
}
