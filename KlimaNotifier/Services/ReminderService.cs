using KlimaNotifier.Data;
using KlimaNotifier.Models;

namespace KlimaNotifier.Services;

/// <summary>
/// Periodic scheduler that runs daily and sends due reminders.
/// </summary>
public sealed class ReminderService
{
    private readonly CustomerRepository _repository;
    private readonly MailService _mailService;
    private readonly NotificationService _notificationService;
    private readonly FileLogger _logger;

    private Timer? _timer;

    public ReminderService(
        CustomerRepository repository,
        MailService mailService,
        NotificationService notificationService,
        FileLogger logger)
    {
        _repository = repository;
        _mailService = mailService;
        _notificationService = notificationService;
        _logger = logger;
    }

    public void Start()
    {
        // Run immediately on startup, then every 24 hours.
        _timer = new Timer(_ => RunCheck(), null, TimeSpan.Zero, TimeSpan.FromHours(24));
        _logger.LogInfo("Reminder timer started.");
    }

    public void RunCheck()
    {
        try
        {
            var customers = _repository.GetAll();
            var today = DateTime.Today;

            foreach (var customer in customers)
            {
                ProcessReminder(customer, 30, customer.Reminder30Sent, today);
                ProcessReminder(customer, 180, customer.Reminder180Sent, today);
                ProcessReminder(customer, 365, customer.Reminder365Sent, today);
            }

            _logger.LogInfo("Daily reminder check completed.");
        }
        catch (Exception ex)
        {
            _logger.LogError($"Reminder check failed: {ex.Message}");
        }
    }

    private void ProcessReminder(Customer customer, int day, bool alreadySent, DateTime today)
    {
        if (alreadySent)
        {
            return;
        }

        var dueDate = customer.PurchaseDate.Date.AddDays(day);
        if (dueDate != today)
        {
            return;
        }

        _notificationService.ShowReminder(customer.FullName, day);
        _mailService.SendReminder(customer, day);
        _repository.MarkReminderSent(customer.Id, day);

        _logger.LogInfo($"Reminder processed for customer #{customer.Id}: {day}-day.");
    }
}
