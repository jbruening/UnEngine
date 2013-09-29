#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public enum LogType
    {
        Error,
        Assert,
        Warning,
        Log,
        Exception
    }
}