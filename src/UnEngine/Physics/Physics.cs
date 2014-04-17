using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
	public class Physics
	{
		public static bool Raycast(Ray ray, out RaycastHit hit, float rayLength, LayerMask layer) 
		{
			hit = new RaycastHit();
			return false; 
		}
	}
}
