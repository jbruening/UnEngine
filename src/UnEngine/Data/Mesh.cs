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
	public sealed class Mesh : Object
	{
		//
		// Summary:
		//     The bounding volume of the mesh.
		public Bounds bounds { get; set; }
		//
		// Summary:
		//     Vertex colors of the mesh.
		public Color[] colors { get; set; }

		//
		// Summary:
		//     Returns state of the Read/Write Enabled checkbox when model was imported.
		public bool isReadable { get; private set; }
		//
		// Summary:
		//     The normals of the mesh.
		public Vector3[] normals { get; set; }
		//
		// Summary:
		//     The number of submeshes. Every material has a separate triangle list.
		public int subMeshCount { get; set; }
		//
		// Summary:
		//     The tangents of the mesh.
		public Vector4[] tangents { get; set; }
		//
		// Summary:
		//     An array containing all triangles in the mesh.
		public int[] triangles { get; set; }
		//
		// Summary:
		//     The base texture coordinates of the mesh.
		public Vector2[] uv { get; set; }
		public Vector2[] uv1 { get; set; }
		//
		// Summary:
		//     The second texture coordinate set of the mesh, if present.
		public Vector2[] uv2 { get; set; }
		//
		// Summary:
		//     Returns the number of vertices in the mesh (Read Only).
		public int vertexCount { get; private set; }
		//
		// Summary:
		//     Returns a copy of the vertex positions or assigns a new vertex positions
		//     array.
		public Vector3[] vertices { get; set; }

		public void Clear() { }
		//
		// Summary:
		//     Clears all vertex data and all triangle indices.
		public void Clear(bool keepVertexLayout) { }

		//
		// Summary:
		//     Returns the index buffer for the submesh.
		public int[] GetIndices(int submesh) { return null; }

		//
		// Summary:
		//     Returns the triangle list for the submesh.
		public int[] GetTriangles(int submesh) { return null; }

		public void MarkDynamic() { }
		public void Optimize() { }
		public void RecalculateBounds() { }
		public void RecalculateNormals() { }

		//
		// Summary:
		//     Sets the triangle list for the submesh.
		public void SetTriangles(int[] triangles, int submesh) { }

		public void UploadMeshData(bool markNoLogerReadable) { }
	}
}
