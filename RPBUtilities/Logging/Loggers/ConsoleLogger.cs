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
            return level switch
            {
                LogLevel.SYSTEM_MESSAGE => ConsoleColor.DarkRed,
                LogLevel.ERROR => ConsoleColor.Red,
                LogLevel.WARNING => ConsoleColor.DarkYellow,
                LogLevel.INFO => ConsoleColor.White,
                LogLevel.SUCCESS => ConsoleColor.Green,
                _ => ConsoleColor.White
            };
        }
    }
}