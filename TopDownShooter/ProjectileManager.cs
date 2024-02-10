using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter {
    public static class ProjectileManager {
        public static Texture2D texture;
        public static List<Projectile> Projectiles { get; } = new();
        public static void Init() {
            texture = Globals.Content.Load<Texture2D>("bullet");
        }
        public static void AddProjectile(ProjectileData data) {
            Projectiles.Add(new(texture, data));
        }
        public static void Update() {
            foreach(var p in Projectiles) {
                p.Update();
            }
            Projectiles.RemoveAll(p => p.LifeSpan < 0);
        }
        public static void Draw() {
            foreach (var p in Projectiles) {
                p.Draw();
            }
        }
    }
}
