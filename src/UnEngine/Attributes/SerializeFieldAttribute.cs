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
    public class SerializeFieldAttribute : System.Attribute
    {
    }
}
