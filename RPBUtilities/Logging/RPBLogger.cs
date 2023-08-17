using System;
using System.Runtime.CompilerServices;

namespace RPBUtilities.Logging
{
    public abstract class RPBLogger : IRPBLogger
    {
        private readonly LogLevel _logLevel;
        private readonly Action<string,LogLevel> _logAction;

        protected RPBLogger(LogType type, LogLevel level = LogLevel.ERROR, Action<string,LogLevel> customLogAction =null)
        {
            _logLevel = level;
            _logAction = _getLogAction(type,customLogAction);
        }

        public void Log(string message, LogLevel level)
        {
            if (_logLevel >= level)
            {
                _logAction(message,level);
            }
        }
        private Action<string,LogLevel> _getLogAction(LogType type, Action<string,LogLevel> customAction = null)
        {
            return type switch
            {
                LogType.CONSOLE => _logConsole,
                LogType.FILE => _logFile,
                LogType.CUSTOM => customAction,
                _ => (s,l) => { }
            };
        }

        protected virtual void _logConsole(string message,LogLevel level){}

        protected virtual void _logFile(string message,LogLevel level){}

        
    }
}