using System;
using System.Runtime.CompilerServices;
//using UnityEngine.Scripting;

namespace UnityEngine {
    internal sealed class DebugLogHandler : ILogHandler {
        public void LogFormat(LogType logType, Object context, string format, params object[] args) {
            switch(logType) {
                case LogType.Log:
                    Console.WriteLine(format, args);
                    break;
                case LogType.Assert:
                case LogType.Warning:
                case LogType.Error:
                case LogType.Exception:
                    Console.Error.WriteLine(format, args);
                    break;
            }
        }

        public void LogException(Exception exception, Object context) {
            Console.Error.WriteLine(exception);
        }
    }
}
