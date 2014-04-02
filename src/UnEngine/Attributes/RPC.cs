using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class RPC : Attribute
	{
	}
}
