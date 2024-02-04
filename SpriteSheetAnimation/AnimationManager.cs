using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteSheetAnimation {
    public class AnimationManager {
        private readonly Dictionary<object, Animation> animations = new();
        private object lastKey;
        public void AddAnimation(object key, Animation animation) {
            animations.Add(key, animation);
            lastKey ??= key;
        }
        public void Update(object key) {
            if(animations.ContainsKey(key)) {
                animations[key].Start();
                animations[key].Update();
                lastKey = key;
            }
            else {
                animations[lastKey].Stop();
                animations[lastKey].Reset();
            }
        }
        public void Draw(Vector2 position) {
            animations[lastKey].Draw(position);
        }
    }
}
