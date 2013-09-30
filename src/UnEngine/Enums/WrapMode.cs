#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public enum WrapMode
    {
        Default = 0,
        Clamp = 1,
        Once = 1,
        Loop = 2,
        PingPong = 4,
        ClampForever = 8,
    }
}