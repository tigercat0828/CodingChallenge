using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopDownShooter {
    public static  class Globals {
        public static float DeltaTime { get; set; }
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static Point Bound { get; set; }
        public static void Update(GameTime gameTime) {
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
