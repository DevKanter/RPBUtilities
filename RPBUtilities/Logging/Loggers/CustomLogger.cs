using System;

namespace RPBUtilities.Logging.Loggers
{
    public class CustomLogger : RPBLogger
    {
        public CustomLogger(Action<string, LogLevel> customLogAction, LogLevel level = LogLevel.ERROR) : base(LogType.CONSOLE, level, customLogAction)
        {

        }
    }
}