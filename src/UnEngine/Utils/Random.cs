using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine {
    public static class Random {
        private static System.Random random = new System.Random();

        /// <summary>
        ///   <para>Initializes the random number generator state with a seed.</para>
        /// </summary>
        /// <param name="seed">Seed used to initialize the random number generator.</param>
        public static void InitState(int seed) {
            random = new System.Random(seed);
        }

        /// <summary>
        ///   <para>Returns a random integer number between min [inclusive] and max [exclusive] (Read Only).</para>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static int Range(int min, int max) {
            return min + random.Next(max - min);
        }

        /// <summary>
        ///   <para>Returns a random float number between and min [inclusive] and max [inclusive] (Read Only).</para>
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static float Range(float min, float max) {
            return (float)(min + random.NextDouble() * (max - min));
        }
    }
}