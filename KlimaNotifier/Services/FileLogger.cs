namespace KlimaNotifier.Services;

/// <summary>
/// Writes timestamped logs to local logs folder.
/// </summary>
public sealed class FileLogger
{
    private readonly string _logDirectory;

    public FileLogger(string basePath)
    {
        _logDirectory = Path.Combine(basePath, "logs");
        Directory.CreateDirectory(_logDirectory);
    }

    public void LogInfo(string message) => Write("INFO", message);
    public void LogError(string message) => Write("ERROR", message);

    private void Write(string level, string message)
    {
        var filePath = Path.Combine(_logDirectory, $"klimanotifier-{DateTime.Now:yyyyMMdd}.log");
        var line = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}{Environment.NewLine}";
        File.AppendAllText(filePath, line);
    }
}
