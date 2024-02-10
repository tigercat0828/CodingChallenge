using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallaxBackground {
    public  class BackgroundManager {
        private readonly List<Layer> layers;
        public BackgroundManager()
        {
            layers = new List<Layer>();
        }
        public void AddLayer(Layer layer) {
            layers.Add(layer);
        }
        public void Update(float movement) {
            foreach (Layer layer in layers) {
                layer.Update(movement);    
            }
        }
        public void Draw() {
            foreach (var layer in layers)
            {
                    layer.Draw();
            }
        }
    }
}
