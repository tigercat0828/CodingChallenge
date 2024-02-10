using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxBackground {
    public class InputManger {
        private readonly float speed = 200f;
        public float Movement { get; set; }
        public void Update() {
            KeyboardState ks = Keyboard.GetState();
            Movement = 0;
            if (ks.IsKeyDown(Keys.D)) {
                Movement = speed;
            } else if (ks.IsKeyDown(Keys.A)) {
                Movement -= speed;
            }
        }
    }
        
}
