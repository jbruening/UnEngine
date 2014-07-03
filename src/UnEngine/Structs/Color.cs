using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
	public struct Color
	{
		public float a;
		public float b;
		public float g;
		public float r;

		public Color(float r, float g, float b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = 1;
		}

		public Color(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public static Color operator -(Color a, Color b)
		{
			return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
		}

		public static bool operator !=(Color lhs, Color rhs)
		{
			return !lhs.Equals(rhs);
		}

		public static Color operator *(Color a, Color b)
		{
			return new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
		}

		public static Color operator *(Color a, float b)
		{
			return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
		}

		public static Color operator *(float b, Color a)
		{
			return new Color(a.r * b, a.g * b, a.b * b, a.a * b);
		}

		public static Color operator /(Color a, float b)
		{
			return new Color(a.r / b, a.g / b, a.b / b, a.a / b);
		}

		public static Color operator +(Color a, Color b)
		{
			return new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
		}

		public static bool operator ==(Color lhs, Color rhs)
		{
			return lhs.Equals(rhs);
		}

		public static implicit operator Vector4(Color c)
		{
			return new Vector4(c.r, c.g, c.b, c.a);
		}

		public static implicit operator Color(Vector4 v)
		{
			return new Color(v.x, v.y, v.z, v.w);
		}


		public static Color black { get { return new Color(0, 0, 0); } }
		public static Color blue { get { return new Color(0, 0, 1); } }
		public static Color clear { get { return new Color(1, 1, 1, 0); } }
		public static Color cyan { get { return new Color(1, 0, 0); } }
		public static Color gray { get { return new Color(0.5f, 0.5f, 0.5f); } }
		public static Color green { get { return new Color(0, 1, 0); } }
		public static Color grey { get { return new Color(0.5f, 0.5f, 0.5f); } }
		public static Color magenta { get { return new Color(1, 0, 0); } }
		public static Color red { get { return new Color(1, 0, 0); } }
		public static Color white { get { return new Color(1, 1, 1); } }
		public static Color yellow { get { return new Color(1.0f, 1.0f, 0.0f); } }

		public float this[int index] 
		{
			get
			{
				switch (index)
				{
					case 0:
						return r;
					case 1:
						return g;
					case 2:
						return b;
					case 3:
						return a;
					default:
						throw new IndexOutOfRangeException("Invalid Color index!");
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						r = value;
						break;
					case 1:
						g = value;
						break;
					case 2:
						b = value;
						break;
					case 3:
						a = value;
						break;
					default:
						throw new IndexOutOfRangeException("Invalid Color index!");
				}
			}
		}

		public static Color Lerp(Color a, Color b, float t)
		{
			if (t < 0f)
				return a;
			if (t > 1f)
				return b;
			return (b - a) * t + a;
		}

		public override bool Equals(object other)
		{
			Color c = (Color)other;
			return (c.r == r && c.g == g && c.b == b && c.a == a);
		}
	}
}
