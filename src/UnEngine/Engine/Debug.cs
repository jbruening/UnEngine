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
            Console.WriteLine (message.ToString ());
        }
        public static void Warning(object message)
        {
            Console.WriteLine (message.ToString ());
        }
        public static void Error(object message)
        {
            Console.WriteLine (message.ToString ());
        }
        public static void Exception(object message)
        {
            Console.WriteLine (message.ToString ());
        }

        public static void Log(object message, Object context)
        {
            Console.WriteLine (message.ToString ());
        }

        public static void LogError(object message)
        {
            Console.WriteLine (message.ToString ());
        }

        public static void LogError(object message, Object context)
        {
            Console.WriteLine (message.ToString ());
        }

        public static void ClearDeveloperConsole(){}

        public static void LogException(Exception exception)
        {
            Console.WriteLine (exception.ToString ());
        }

        public static void LogException(Exception exception, Object context)
        {
            Console.WriteLine (exception.ToString ());
        }

		public static void LogWarning(object message)
		{
            Console.WriteLine (message.ToString ());
		}

		public static void LogWarning(object message, Object context)
		{
            Console.WriteLine (message.ToString ());
		}
    }
}