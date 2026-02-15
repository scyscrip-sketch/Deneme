using KlimaNotifier.Models;
using KlimaNotifier.Services;

namespace KlimaNotifier.Forms;

/// <summary>
/// Simple form for editing smtpconfig.json values.
/// </summary>
public class SmtpSettingsForm : Form
{
    private readonly SmtpConfigService _configService;

    private readonly TextBox _host = new();
    private readonly NumericUpDown _port = new() { Minimum = 1, Maximum = 65535, Value = 587 };
    private readonly TextBox _user = new();
    private readonly TextBox _password = new() { UseSystemPasswordChar = true };
    private readonly TextBox _fromEmail = new();
    private readonly CheckBox _ssl = new() { Text = "Enable SSL", Checked = true };

    public SmtpSettingsForm(SmtpConfigService configService)
    {
        _configService = configService;

        Text = "SMTP Settings";
        Width = 450;
        Height = 300;

        BuildUi();
        LoadData();
    }

    private void BuildUi()
    {
        Controls.Add(new Label { Text = "Host", Left = 20, Top = 20, Width = 100 });
        _host.SetBounds(130, 18, 250, 24);
        Controls.Add(_host);

        Controls.Add(new Label { Text = "Port", Left = 20, Top = 55, Width = 100 });
        _port.SetBounds(130, 53, 120, 24);
        Controls.Add(_port);

        Controls.Add(new Label { Text = "User", Left = 20, Top = 90, Width = 100 });
        _user.SetBounds(130, 88, 250, 24);
        Controls.Add(_user);

        Controls.Add(new Label { Text = "Password", Left = 20, Top = 125, Width = 100 });
        _password.SetBounds(130, 123, 250, 24);
        Controls.Add(_password);

        Controls.Add(new Label { Text = "From Email", Left = 20, Top = 160, Width = 100 });
        _fromEmail.SetBounds(130, 158, 250, 24);
        Controls.Add(_fromEmail);

        _ssl.SetBounds(130, 188, 120, 24);
        Controls.Add(_ssl);

        var save = new Button { Text = "Save", Left = 130, Top = 220, Width = 90 };
        save.Click += (_, _) => Save();
        Controls.Add(save);
    }

    private void LoadData()
    {
        var s = _configService.Load();
        _host.Text = s.Host;
        _port.Value = s.Port;
        _user.Text = s.User;
        _password.Text = s.Password;
        _fromEmail.Text = s.FromEmail;
        _ssl.Checked = s.EnableSsl;
    }

    private void Save()
    {
        var settings = new SmtpSettings
        {
            Host = _host.Text.Trim(),
            Port = (int)_port.Value,
            User = _user.Text.Trim(),
            Password = _password.Text,
            FromEmail = _fromEmail.Text.Trim(),
            EnableSsl = _ssl.Checked
        };

        _configService.Save(settings);
        MessageBox.Show("SMTP settings saved.", "KlimaNotifier");
        Close();
    }
}
