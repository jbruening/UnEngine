using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// 
        /// </summary>
        public float x;
        /// <summary>
        /// 
        /// </summary>
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

		public static Vector2 operator +(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x + b.x, a.y + b.y);
		}

		public static Vector2 operator -(Vector2 a, Vector2 b)
		{
			return new Vector2(a.x - b.x, a.y - b.y);
		}

		public static Vector2 operator -(Vector2 a)
		{
			return new Vector2(-a.x, -a.y);
		}

		public static Vector2 operator *(float d, Vector2 a)
		{
			return new Vector2(a.x * d, a.y * d);
		}

		public static Vector2 operator *(Vector2 a, float d)
		{
			return new Vector2(a.x * d, a.y * d);
		}

		public static Vector2 operator /(Vector2 a, float d)
		{
			return new Vector2(a.x / d, a.y / d);
		}

		public static float Dot (Vector2 a, Vector2 b)
		{
			return a.x * b.x + a.y * b.y;
		}

		public Vector2 normalized
		{
			get
			{
				var length = magnitude;
				return new Vector2(x / magnitude, y / magnitude);
			}
		}

		public float magnitude
		{
			get
			{
				return (float)Math.Sqrt(x * (double)x + y * (double)y);
			}
		}

		public float sqrMagnitude
		{
			get
			{
				return (float)(x * (double)x + y * (double)y);
			}
		}

		public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
		{
			var vector2 = target - current;
			var magnitude = vector2.magnitude;
			if (magnitude <= (double)maxDistanceDelta || magnitude == 0.0)
				return target;
			return current + vector2 / magnitude * maxDistanceDelta;
		}

		public static Vector2 Lerp(Vector2 from, Vector2 to, float t)
		{
			if (t < 0f)
				return from;
			if (t > 1f)
				return to;
			return (to - from) * t + from;
		}
    }
}
