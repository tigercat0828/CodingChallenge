using Microsoft.Win32.SafeHandles;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter {
    public class GameManager {
        private readonly Player player;
        public GameManager()
        {
            ProjectileManager.Init();
            player = new Player(
                Globals.Content.Load<Texture2D>("player"),
                new(Globals.Bound.X/2, Globals.Bound.Y/2));

            ZombieManager.Init();
            ZombieManager.AddZombie();
        }
        public void Update() {
            InputManager.Update();
            player.Update();
            ZombieManager.Update(player);
            ProjectileManager.Update();

        }
        public void Draw() {
            ProjectileManager.Draw();
            player.Draw();
            ZombieManager.Draw();
        }
    }
}
