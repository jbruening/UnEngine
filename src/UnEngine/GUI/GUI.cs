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
    public static class GUI
    {
        public static bool changed { get { return false; } }

        public static void DragWindow (Rect position) { }

		public static void DragWindow() { }
    }
}
