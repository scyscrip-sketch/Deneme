using System.Net;
using System.Net.Mail;
using KlimaNotifier.Models;

namespace KlimaNotifier.Services;

/// <summary>
/// Sends reminder emails through configurable SMTP server.
/// </summary>
public sealed class MailService
{
    private readonly SmtpConfigService _smtpConfigService;
    private readonly FileLogger _logger;

    public MailService(SmtpConfigService smtpConfigService, FileLogger logger)
    {
        _smtpConfigService = smtpConfigService;
        _logger = logger;
    }

    public void SendReminder(Customer customer, int dueDay)
    {
        SmtpSettings settings = _smtpConfigService.Load();

        using var client = new SmtpClient(settings.Host, settings.Port)
        {
            EnableSsl = settings.EnableSsl,
            Credentials = new NetworkCredential(settings.User, settings.Password)
        };

        string subject = $"Klima maintenance reminder: {dueDay} days";
        string body = $"Dear {customer.FullName},\n\n" +
                      $"This is your {dueDay}-day reminder after your climate system purchase date ({customer.PurchaseDate:yyyy-MM-dd}).\n" +
                      "Please contact us for scheduled maintenance if needed.\n\n" +
                      "Regards,\nKlimaNotifier";

        using var message = new MailMessage(settings.FromEmail, customer.Email, subject, body);
        client.Send(message);

        _logger.LogInfo($"Email sent to {customer.Email} for {dueDay}-day reminder.");
    }
}
