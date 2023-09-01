using System;

namespace RPBUtilities.Logging.Loggers
{
    public class ConsoleLogger : RPBLogger
    {
        public ConsoleLogger(LogLevel level = LogLevel.ERROR) : base(LogType.CONSOLE, level) { }

        protected override void _logConsole(string message, LogLevel level)
        {
            Console.ForegroundColor = _getConsoleColor(level);
            Console.WriteLine(message);
        }
        private ConsoleColor _getConsoleColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.FATAL_ERROR:
                    return ConsoleColor.DarkRed;
                case LogLevel.ERROR:
                    return ConsoleColor.Red;
                case LogLevel.WARNING:
                    return ConsoleColor.DarkYellow;
                case LogLevel.INFO:
                    return ConsoleColor.White;
                case LogLevel.SUCCESS:
                    return ConsoleColor.Green;
                case LogLevel.SYSTEM_MESSAGE:
                    return ConsoleColor.Gray;
                default:
                    return ConsoleColor.White;
            }
        }
    }
}