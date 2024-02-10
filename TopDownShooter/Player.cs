using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace TopDownShooter {
    public class Player : Sprite {
        public Player(Texture2D texture, Vector2 position) : base(texture, position) {

        }
        public void Update() {
            if(InputManager.Direction != Vector2.Zero) {
                var dir = Vector2.Normalize(InputManager.Direction);
                Position += dir * Speed * Globals.DeltaTime;
                Position = new Vector2(
                    Math.Clamp(Position.X + (dir.X * Speed * Globals.DeltaTime), 0, Globals.Bound.X),
                    Math.Clamp(Position.Y + (dir.Y * Speed * Globals.DeltaTime), 0, Globals.Bound.Y));
            }
            var toMouse = InputManager.MousePosition - Position;
            Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

            if (InputManager.MouseClicked) {
                Fire();
            }
        }

        private void Fire() {
            ProjectileData pd = new() {
                Position = Position,
                Rotation = Rotation,
                LifeSpan = 2,
                Speed = 600
            };
            ProjectileManager.AddProjectile(pd);
        }
    }
}
