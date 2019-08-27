///****************************************************************************
// * Description:Common log 
// *
// * Author: hiramtan@live.com
// ****************************************************************************/

using System;

namespace HiFramework
{
    public static class Log
    {
        /// <summary>
        /// If info is on
        /// </summary>
        public static bool IsInfoOn = true;

        /// <summary>
        /// If warning is on
        /// </summary>
        public static bool IsWarningOn = true;

        /// <summary>
        /// If error is on
        /// </summary>
        public static bool IsErrorOn = true;

        /// <summary>
        /// When info print
        /// </summary>
        public static event Action<ILogHandler, object[]> OnInfo;

        /// <summary>
        /// When warning print
        /// </summary>
        public static event Action<ILogHandler, object[]> OnWarning;

        /// <summary>
        /// When error print
        /// </summary>
        public static event Action<ILogHandler, object[]> OnError;

        /// <summary>
        /// Handler of log
        /// </summary>
        private static ILogHandler _logHandler;

        /// <summary>
        /// Log Handler
        /// </summary>
        public static ILogHandler LogHandler
        {
            get
            {
                if (_logHandler == null)
                {
                    _logHandler = new ConsoleLogger();
                }
                return _logHandler;
            }
            set
            {
                _logHandler = value;
            }
        }

        /// <summary>
        /// Log info
        /// </summary>
        /// <param name="args"></param>
        public static void Info(params object[] args)
        {
            if (IsInfoOn)
            {
                if (LogHandler != null)
                {
                    LogHandler.Info(args);
                }
                if (OnInfo != null)
                {
                    OnInfo.Invoke(LogHandler, args);
                }
            }
        }

        /// <summary>
        /// Log warning
        /// </summary>
        /// <param name="args"></param>
        public static void Warning(params object[] args)
        {
            if (IsWarningOn)
            {
                if (LogHandler != null)
                {
                    LogHandler.Warning(args);
                }
                if (OnWarning != null)
                {
                    OnWarning.Invoke(LogHandler, args);
                }
            }
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="args"></param>
        public static void Error(params object[] args)
        {
            if (IsErrorOn)
            {
                if (LogHandler != null)
                {
                    LogHandler.Error(args);
                }
                if (OnError != null)
                {
                    OnError.Invoke(LogHandler, args);
                }
            }
        }

        /// <summary>
        /// Get common format of param
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string GetFormat(object args)
        {
            return "[" + args.ToString() + "]";
        }
    }
}