using Microsoft.Toolkit.Uwp.Notifications;

namespace KlimaNotifier.Services;

/// <summary>
/// Displays Windows toast notifications.
/// </summary>
public sealed class NotificationService
{
    private readonly FileLogger _logger;

    public NotificationService(FileLogger logger)
    {
        _logger = logger;
    }

    public void ShowReminder(string customerName, int dueDay)
    {
        string text = $"{customerName}: {dueDay}-day reminder is due.";

        try
        {
            new ToastContentBuilder()
                .AddText("KlimaNotifier Reminder")
                .AddText(text)
                .Show();

            _logger.LogInfo($"Toast notification shown: {text}");
        }
        catch (Exception ex)
        {
            // In case app identity/OS settings block toast, still keep log.
            _logger.LogError($"Toast notification failed: {ex.Message}");
        }
    }
}
