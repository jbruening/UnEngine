using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public sealed class Debug
    {
        public static void Log(object message)
        {
            
        }
        public static void Warning(object message)
        {
            
        }
        public static void Error(object message)
        {
            
        }
        public static void Exception(object message)
        {   
        }

        public static void Log(object message, Object context)
        {
        }

        public static void LogError(object message)
        {
        }

        public static void LogError(object message, Object context)
        {
        }

        public static void ClearDeveloperConsole(){}

        public static void LogException(Exception exception)
        {
        }

        public static void LogException(Exception exception, Object context)
        {
        }

		public static void LogWarning(object message)
		{
		}

		public static void LogWarning(object message, Object context)
		{
		}
    }
}