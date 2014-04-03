using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine
{
	public class WaitForSeconds : YieldInstruction
	{
		public float Duration { get; private set; }
		public WaitForSeconds(float seconds)
		{
			Duration = seconds;
		}
	}
}
