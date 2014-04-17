using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    
    public class Application
    {
		public static bool isPlaying { get { return true; } }
		public static bool isEditor { get { return false; } }
		public static bool runInBackground { get; set; }
		public static int loadedLevel { get { return 0; } }
		public static string loadedLevelName { get { return ""; } }
		public static bool isLoadingLevel { get { return false; } }
		public static string persistentDataPath { get { return ""; } }

        public delegate void LogCallback(string logString, string stackTrace, LogType type);

        public static void RegisterLogCallback(LogCallback handler)
        {
            throw new NotImplementedException();
        }

		public static void LoadLevel(int levelNumber) { }
		public static void LoadLevel(string levelName) { }

		public static void Quit()
		{
			UnEngine.InternalEngine.EngineState.Instance.Quit();
		}
    }
}
