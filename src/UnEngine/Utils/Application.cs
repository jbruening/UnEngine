using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    
    public class Application
    {
        public delegate void LogCallback(string logString, string stackTrace, LogType type);

        public static void RegisterLogCallback(LogCallback handler)
        {
            throw new NotImplementedException();
        }
    }
}
