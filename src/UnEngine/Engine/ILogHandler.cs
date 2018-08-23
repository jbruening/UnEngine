using System;

namespace UnityEngine {
    public interface ILogHandler {
        /// <summary>
        ///   <para>Logs a formatted message.</para>
        /// </summary>
        /// <param name="logType">The type of the log message.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        void LogFormat(LogType logType, Object context, string format, params object[] args);

        /// <summary>
        ///   <para>A variant of ILogHandler.LogFormat that logs an exception message.</para>
        /// </summary>
        /// <param name="exception">Runtime Exception.</param>
        /// <param name="context">Object to which the message applies.</param>
        void LogException(Exception exception, Object context);
    }
}
