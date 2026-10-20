
using System;
using System.IO;

namespace RyvenTweaker.Services
{
    public sealed class Logger
    {
        private readonly string _logDirectory;
        private readonly string _logFile;

        public Logger()
        {
            _logDirectory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "RyvenTweaker");

            _logFile = Path.Combine(_logDirectory, "ryven.log");
        }

        public void Info(string message)
        {
            Write("INFO", message);
        }

        public void Warning(string message)
        {
            Write("WARNING", message);
        }

        public void Error(string message)
        {
            Write("ERROR", message);
        }

        private void Write(string level, string message)
        {
            try
            {
                Directory.CreateDirectory(_logDirectory);

                string entry =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                    $"[{level}] {message}{Environment.NewLine}";

                File.AppendAllText(_logFile, entry);
            }
            catch (IOException)
            {
                // Logging must not crash the application.
            }
            catch (UnauthorizedAccessException)
            {
                // Continue if the log location is unavailable.
            }
        }

        public string GetLogPath()
        {
            return _logFile;
        }
    }
}
