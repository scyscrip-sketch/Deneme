namespace KlimaNotifier.Models;

/// <summary>
/// Customer entity persisted in SQLite.
/// </summary>
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }

    // Reminder flags prevent duplicate sends.
    public bool Reminder30Sent { get; set; }
    public bool Reminder180Sent { get; set; }
    public bool Reminder365Sent { get; set; }

    public string FullName => $"{FirstName} {LastName}".Trim();
}
