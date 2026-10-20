
using System;
using System.IO;

namespace RyvenTweaker.Services;

public sealed class Logger
{
    private readonly string _path = Path.Combine(
        Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
        "RyvenTweaker",
        "ryven.log"
    );

    private void Write(string level, string msg)
    {
        try
        {
            Directory.CreateDirectory(
                Path.GetDirectoryName(_path)!
            );

            File.AppendAllText(
                _path,
                $"{DateTime.Now:u} [{level}] {msg}{Environment.NewLine}"
            );
        }
        catch (IOException) { }
        catch (UnauthorizedAccessException) { }
    }

    public void Info(string msg) => Write("INFO", msg);

    public void Error(string msg) => Write("ERROR", msg);
}
