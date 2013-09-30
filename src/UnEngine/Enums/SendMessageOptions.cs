#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public enum SendMessageOptions
    {
        RequireReceiver,
        DontRequireReceiver
    }
}