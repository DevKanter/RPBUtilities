using System;

namespace RPBUtilities.Logging
{
    public abstract class RPBLogger : IRPBLogger
    {
        private readonly Action<string, LogLevel> _logAction;
        private readonly LogLevel _logLevel;

        protected RPBLogger(LogType type, LogLevel level = LogLevel.ERROR,
            Action<string, LogLevel> customLogAction = null)
        {
            _logLevel = level;
            _logAction = _getLogAction(type, customLogAction);
        }

        public void Log(string message, LogLevel level)
        {
            if (_logLevel >= level) _logAction(message, level);
        }

        private Action<string, LogLevel> _getLogAction(LogType type, Action<string, LogLevel> customAction = null)
        {
            switch (type)
            {
                case LogType.CONSOLE:
                    return _logConsole;
                case LogType.FILE:
                    return _logFile;
                case LogType.CUSTOM:
                    return customAction;
                default:
                    return (s, l) => { };
            }
        }

        protected virtual void _logConsole(string message, LogLevel level)
        {
        }

        protected virtual void _logFile(string message, LogLevel level)
        {
        }
    }
}