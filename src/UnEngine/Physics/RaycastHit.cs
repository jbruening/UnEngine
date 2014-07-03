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
	public struct RaycastHit
	{
		public Vector3 barycentricCoordinate;
		public Collider collider;
		public float distance;
		public Vector2 lightmapCoord;
		public Vector3 normal;
		public Vector3 point;
		public Rigidbody rigidbody;
		public Vector2 textureCoord;
		public Vector2 textureCoord1;
		public Vector2 textureCoord2;
		public Transform transform;
		public int triangleIndex;
	}
}
