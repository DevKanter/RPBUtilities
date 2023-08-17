using System;
using System.IO;
using System.Security.Cryptography;

namespace RPBUtilities.Logging.Loggers
{
    public class FileLogger : RPBLogger
    {
        private readonly string _path;

        public FileLogger(string path, LogLevel level = LogLevel.ERROR) : base(LogType.FILE, level)
        {
            _path = path;
        }

        protected override void _logFile(string message, LogLevel level)
        {
            var date = DateTime.UtcNow;

            File.AppendAllLinesAsync($"{_path}+{date:yyyy MM dd}.log", new[] { $"[{date:HH:mm:ss.fff}] : {message}"});
        }
    }
}