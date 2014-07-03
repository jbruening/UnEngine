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
	public sealed class Gizmos
	{
		public static Color color { get; set; }
		public static Matrix4x4 matrix { get; set; }

		public static void DrawCube(Vector3 center, Vector3 size) { }
		public static void DrawFrustum(Vector3 center, float fov, float maxRange, float minRange, float aspect) { }

		public static void DrawGUITexture(Rect screenRect, Texture texture) { }
		public static void DrawGUITexture(Rect screenRect, Texture texture, Material mat) { }

		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder) { }
		public static void DrawGUITexture(Rect screenRect, Texture texture, int leftBorder, int rightBorder, int topBorder, int bottomBorder, Material mat) { }

		public static void DrawIcon(Vector3 center, string name) { }
		public static void DrawIcon(Vector3 center, string name, bool allowScaling) { }
		public static void DrawLine(Vector3 from, Vector3 to) { }
		public static void DrawRay(Ray r) { }
		public static void DrawRay(Vector3 from, Vector3 direction) { }
		public static void DrawSphere(Vector3 center, float radius) { }
		public static void DrawWireCube(Vector3 center, Vector3 size) { }
		public static void DrawWireSphere(Vector3 center, float radius) { }
	}
}
