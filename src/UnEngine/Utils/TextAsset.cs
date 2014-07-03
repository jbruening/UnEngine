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
	public class TextAsset : Object
	{
		public byte[] bytes { get; set; }
		public string text { get; set; }
	}
}
