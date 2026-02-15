using System.Text.Json;
using KlimaNotifier.Models;

namespace KlimaNotifier.Services;

/// <summary>
/// Handles loading/saving SMTP settings from smtpconfig.json.
/// </summary>
public sealed class SmtpConfigService
{
    private readonly string _configPath;
    private readonly FileLogger _logger;

    public SmtpConfigService(string basePath, FileLogger logger)
    {
        _configPath = Path.Combine(basePath, "smtpconfig.json");
        _logger = logger;
    }

    public SmtpSettings Load()
    {
        if (!File.Exists(_configPath))
        {
            var defaults = new SmtpSettings();
            Save(defaults);
            _logger.LogInfo("smtpconfig.json not found; default file created.");
            return defaults;
        }

        var json = File.ReadAllText(_configPath);
        return JsonSerializer.Deserialize<SmtpSettings>(json) ?? new SmtpSettings();
    }

    public void Save(SmtpSettings settings)
    {
        var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_configPath, json);
        _logger.LogInfo("SMTP settings saved.");
    }
}
