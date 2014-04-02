using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
	public sealed class Ping
	{
		public Ping(string address) { }

		public bool isDone { get; set; }
		public int time { get; set; }
	}
}
