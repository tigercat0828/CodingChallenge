using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxBackground {
    public  class GameManager {
        private readonly BackgroundManager BgManager = new();
        private readonly InputManger inputManager = new();
        public GameManager()
        {
            BgManager.AddLayer(new(Globals.Content.Load<Texture2D>("Layer0"), 0.1f, 0.0f));
            BgManager.AddLayer(new(Globals.Content.Load<Texture2D>("Layer1"), 0.2f, 0.2f));
            BgManager.AddLayer(new(Globals.Content.Load<Texture2D>("Layer2"), 0.3f, 0.5f));
            BgManager.AddLayer(new(Globals.Content.Load<Texture2D>("Layer3"), 0.4f, 1.0f));
            BgManager.AddLayer(new(Globals.Content.Load<Texture2D>("Layer4"), 0.5f, 0.2f));
        }
        public void Update() {
            inputManager.Update();
            BgManager.Update(inputManager.Movement);
        }
        public void Draw() {
            BgManager.Draw();
        }
    }
}
