
using System;
using System.IO;
using System.Text.Json;

namespace RyvenTweaker.Services
{
    public sealed class BackupService
    {
        private readonly string _backupDirectory;

        public BackupService()
        {
            _backupDirectory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "RyvenTweaker",
                "Backups");

            Directory.CreateDirectory(_backupDirectory);
        }

        public string SaveBackup<T>(string name, T data)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "A backup name is required.", nameof(name));

            foreach (char character in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(character, '_');
            }

            string filePath = Path.Combine(
                _backupDirectory, name + ".json");

            string json = JsonSerializer.Serialize(
                data,
                new JsonSerializerOptions { WriteIndented = true });

            string temporaryPath = filePath + ".tmp";

            File.WriteAllText(temporaryPath, json);
            File.Move(temporaryPath, filePath, true);

            return filePath;
        }

        public T? LoadBackup<T>(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "A backup name is required.", nameof(name));

            foreach (char character in Path.GetInvalidFileNameChars())
            {
                name = name.Replace(character, '_');
            }

            string filePath = Path.Combine(
                _backupDirectory, name + ".json");

            if (!File.Exists(filePath))
                return default;

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<T>(json);
        }

        public string GetBackupDirectory()
        {
            return _backupDirectory;
        }
    }
}
