using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace TopDownShooter {
    public static class ZombieManager {

        public static List<Zombie> Zombies { get; } = new();
        public static Texture2D texture;
        private static float spawnCooldown;
        private static float spawnTime;
        private static Random random;
        private static int padding;

        public static void Init() {
            texture = Globals.Content.Load<Texture2D>("zombie");
            spawnCooldown = 1;
            spawnTime = spawnCooldown;
            random = new();
            padding = texture.Width / 2;
        }
        private static Vector2 RandomPosition() {
            float w = Globals.Bound.X;
            float h = Globals.Bound.Y;
            Vector2 position = new();
            if (random.NextDouble() < w / (w + h)) {
                position.X = (int)(random.NextDouble() * w);
                position.Y = (int)(random.NextDouble()<0.5 ? -padding:h+padding);
            }
            else {
                position.X = (int)(random.NextDouble() * h);
                position.Y = (int)(random.NextDouble() < 0.5 ? -padding : w + padding);
            }
            return position;
        }
        public static void AddZombie() {
            Zombies.Add(new(texture, RandomPosition()));
        }
        public static void Update(Player player) {

            spawnTime -= Globals.DeltaTime;
            if(spawnTime < 0) {
                spawnTime += spawnCooldown;
                AddZombie();
            }
            foreach(var zombie in Zombies) {
                zombie.Update(player);
            }
        }
        public static void Draw() {
            foreach (var zombie in Zombies) {
                zombie.Draw();
            }
        }

    }
}
