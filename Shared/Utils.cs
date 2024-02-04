using System;

namespace Shared {
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
        public static float Random() {
            return random.Next();
        }
        
        public static float Random(float min, float max) {
            return min+ (max-min) * random.NextSingle();
        }
        public static float Map(float value, float a, float b, float A, float B) {
            return A + (value - a) / (b - a) * (B - A);
        }

    }
}
