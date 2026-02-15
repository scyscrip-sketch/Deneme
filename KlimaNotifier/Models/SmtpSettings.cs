namespace KlimaNotifier.Models;

/// <summary>
/// Configurable SMTP settings loaded from smtpconfig.json.
/// </summary>
public class SmtpSettings
{
    public string Host { get; set; } = "smtp.example.com";
    public int Port { get; set; } = 587;
    public string User { get; set; } = "your-user@example.com";
    public string Password { get; set; } = "change-me";
    public string FromEmail { get; set; } = "your-user@example.com";
    public bool EnableSsl { get; set; } = true;
}
