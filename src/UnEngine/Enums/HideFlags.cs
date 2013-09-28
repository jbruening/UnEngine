using System;

#if DEBUG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    [Flags]
    public enum HideFlags
    {
        HideInHierarchy = 1,
        HideInInspector = 2,
        DontSave = 4,
        NotEditable = 8,
        HideAndDontSave = NotEditable | DontSave | HideInHierarchy,
    }
}