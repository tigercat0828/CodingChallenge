using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetAnimation {
    public class GameManager {
        private Coin coin;
        private Player player;
        public void Initialize() {
            coin = new(new(300, 300));
            player = new();
        }
        public void Update() {
            InputManager.Update();
            coin.Update();
            player.Update();
        }
        public void Draw() {
            coin.Draw();
            player.Draw();
        }
    }
}
