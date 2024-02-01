using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingSand {
    public static class Utils {
        readonly static Random random;
        static Utils() {
            random = new Random();
        }
        /// <summary>
        /// return [min, max)
        /// </summary>
        public static int Random(int min, int max) {
            return random.Next(min, max);
        }
    }
}
