
using System;
using System.IO;

namespace RyvenTweaker.Services
{
    public sealed class Logger
    {
        private static readonly string LogDirectory =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "RyvenTweaker"
            );

        private static readonly string LogFile =
            Path.Combine(LogDirectory, "ryven.log");

        public void Info(string message)
        {
            Write("INFO", message);
        }

        public void Error(string message)
        {
            Write("ERROR", message);
        }

        public void Warning(string message)
        {
            Write("WARNING", message);
        }

        private static void Write(string level, string message)
        {
            try
            {
                Directory.CreateDirectory(LogDirectory);

                string entry =
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}{Environment.NewLine}";

                File.AppendAllText(LogFile, entry);
            }
            catch (IOException)
            {
                // Logging must not crash the application.
            }
            catch (UnauthorizedAccessException)
            {
                // Logging must not crash the application.
            }
        }
    }
}
