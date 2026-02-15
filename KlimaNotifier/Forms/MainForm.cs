using KlimaNotifier.Data;
using KlimaNotifier.Models;
using KlimaNotifier.Services;

namespace KlimaNotifier.Forms;

/// <summary>
/// Main UI for adding customers, viewing records, and managing SMTP settings.
/// </summary>
public class MainForm : Form
{
    private readonly CustomerRepository _repository;
    private readonly SmtpConfigService _smtpConfigService;
    private readonly ReminderService _reminderService;
    private readonly FileLogger _logger;

    private readonly DataGridView _grid = new() { Dock = DockStyle.Fill, ReadOnly = true, AutoGenerateColumns = true };
    private readonly TextBox _firstNameBox = new();
    private readonly TextBox _lastNameBox = new();
    private readonly TextBox _phoneBox = new();
    private readonly TextBox _emailBox = new();
    private readonly DateTimePicker _purchaseDatePicker = new() { Format = DateTimePickerFormat.Short };

    public MainForm(CustomerRepository repository, SmtpConfigService smtpConfigService, ReminderService reminderService, FileLogger logger)
    {
        _repository = repository;
        _smtpConfigService = smtpConfigService;
        _reminderService = reminderService;
        _logger = logger;

        Text = "KlimaNotifier";
        Width = 1100;
        Height = 650;

        var panel = BuildInputPanel();
        Controls.Add(_grid);
        Controls.Add(panel);

        LoadCustomers();
    }

    private Control BuildInputPanel()
    {
        var panel = new Panel { Dock = DockStyle.Top, Height = 160 };
        var addButton = new Button { Text = "Add Customer", Width = 130, Left = 20, Top = 110 };
        var smtpButton = new Button { Text = "SMTP Settings", Width = 130, Left = 170, Top = 110 };
        var runCheckButton = new Button { Text = "Run Reminder Check", Width = 150, Left = 320, Top = 110 };

        addButton.Click += (_, _) => AddCustomer();
        smtpButton.Click += (_, _) => OpenSmtpSettings();
        runCheckButton.Click += (_, _) =>
        {
            _reminderService.RunCheck();
            MessageBox.Show("Reminder check completed. See logs for details.", "KlimaNotifier");
            LoadCustomers();
        };

        panel.Controls.Add(new Label { Text = "First Name", Left = 20, Top = 15, Width = 100 });
        _firstNameBox.SetBounds(120, 12, 130, 24);
        panel.Controls.Add(_firstNameBox);

        panel.Controls.Add(new Label { Text = "Last Name", Left = 270, Top = 15, Width = 100 });
        _lastNameBox.SetBounds(370, 12, 130, 24);
        panel.Controls.Add(_lastNameBox);

        panel.Controls.Add(new Label { Text = "Phone", Left = 520, Top = 15, Width = 100 });
        _phoneBox.SetBounds(620, 12, 140, 24);
        panel.Controls.Add(_phoneBox);

        panel.Controls.Add(new Label { Text = "Email", Left = 20, Top = 55, Width = 100 });
        _emailBox.SetBounds(120, 52, 240, 24);
        panel.Controls.Add(_emailBox);

        panel.Controls.Add(new Label { Text = "Purchase Date", Left = 380, Top = 55, Width = 100 });
        _purchaseDatePicker.SetBounds(480, 52, 130, 24);
        panel.Controls.Add(_purchaseDatePicker);

        panel.Controls.Add(addButton);
        panel.Controls.Add(smtpButton);
        panel.Controls.Add(runCheckButton);

        return panel;
    }

    private void AddCustomer()
    {
        if (string.IsNullOrWhiteSpace(_firstNameBox.Text) ||
            string.IsNullOrWhiteSpace(_lastNameBox.Text) ||
            string.IsNullOrWhiteSpace(_emailBox.Text))
        {
            MessageBox.Show("First name, last name, and email are required.", "Validation");
            return;
        }

        var customer = new Customer
        {
            FirstName = _firstNameBox.Text.Trim(),
            LastName = _lastNameBox.Text.Trim(),
            Phone = _phoneBox.Text.Trim(),
            Email = _emailBox.Text.Trim(),
            PurchaseDate = _purchaseDatePicker.Value.Date
        };

        _repository.Add(customer);
        _logger.LogInfo($"Customer added: {customer.FullName} ({customer.Email})");

        _firstNameBox.Clear();
        _lastNameBox.Clear();
        _phoneBox.Clear();
        _emailBox.Clear();
        _purchaseDatePicker.Value = DateTime.Today;

        LoadCustomers();
    }

    private void OpenSmtpSettings()
    {
        using var form = new SmtpSettingsForm(_smtpConfigService);
        form.ShowDialog(this);
    }

    private void LoadCustomers()
    {
        _grid.DataSource = null;
        _grid.DataSource = _repository.GetAll();
    }
}
