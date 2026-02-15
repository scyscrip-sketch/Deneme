using KlimaNotifier.Data;
using KlimaNotifier.Forms;
using KlimaNotifier.Services;

namespace KlimaNotifier;

internal static class Program
{
    /// <summary>
    /// Application entry point. Initializes persistence/services and starts WinForms UI.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        var logger = new FileLogger(AppContext.BaseDirectory);
        var smtpConfigService = new SmtpConfigService(AppContext.BaseDirectory, logger);
        var databaseInitializer = new DatabaseInitializer(AppContext.BaseDirectory, logger);
        databaseInitializer.Initialize();

        var repository = new CustomerRepository(databaseInitializer.ConnectionString);
        var mailService = new MailService(smtpConfigService, logger);
        var notificationService = new NotificationService(logger);
        var reminderService = new ReminderService(repository, mailService, notificationService, logger);

        reminderService.Start();
        Application.Run(new MainForm(repository, smtpConfigService, reminderService, logger));
    }
}
