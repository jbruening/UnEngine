using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
	public static class Random
	{
		private static System.Random random = new System.Random();
		public static float Range(float min, float max)
		{
			return (float)(min + random.NextDouble() * (max - min));
		}

		public static int Range(int min, int max)
		{
			return min + random.Next(max - min);
		}
	}
}
