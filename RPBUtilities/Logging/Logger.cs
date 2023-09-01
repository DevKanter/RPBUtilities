using System;
using System.Collections.Generic;
using System.Linq;

namespace RPBUtilities.Logging
{
    public static class Logger<TLoggerEnum> where TLoggerEnum : unmanaged,Enum
    {
        private static Dictionary<int, IRPBLogger> _loggers = new Dictionary<int, IRPBLogger>();
        public static void Initialize(Dictionary<TLoggerEnum, IRPBLogger> loggers)
        {
            foreach (var rpbLogger in loggers)
            {
                _loggers.Add(UConverter.ToInt(rpbLogger.Key),rpbLogger.Value);
            }
   
        }

        public static void Log(string message, LogLevel level, TLoggerEnum loggerRef)
        {
            if (!_loggers.TryGetValue(UConverter.ToInt(loggerRef), out var logger))
            {
                throw new KeyNotFoundException($"no instance of {loggerRef} found!");
            }
            logger.Log(message, level);
        }
    }
}