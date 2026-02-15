# KlimaNotifier (.NET 7 WinForms)

KlimaNotifier is a Windows desktop application that stores customer purchase data in SQLite and automatically sends 30/180/365-day reminders via desktop toast + SMTP email.

## Features

- Local SQLite database (`klimanotifier.db`) auto-created at startup.
- Customers table with: `id`, `firstName`, `lastName`, `phone`, `email`, `purchaseDate`, `reminder30Sent`, `reminder180Sent`, `reminder365Sent`.
- Daily timer check (every 24 hours).
- Windows toast notification for due reminders.
- SMTP email delivery using editable `smtpconfig.json` and SMTP settings form.
- Reminder sent flags updated in DB to avoid duplicates.
- File logging in `logs/klimanotifier-YYYYMMDD.log`.

## Project Structure

- `Program.cs` – startup, dependency wiring.
- `Data/DatabaseInitializer.cs` – schema creation/migration.
- `Data/CustomerRepository.cs` – customer CRUD and sent flag updates.
- `Services/ReminderService.cs` – daily reminder logic.
- `Services/MailService.cs` – SMTP sending.
- `Services/NotificationService.cs` – Windows toast notifications.
- `Services/SmtpConfigService.cs` – load/save SMTP JSON config.
- `Forms/MainForm.cs` – customer UI and manual reminder run.
- `Forms/SmtpSettingsForm.cs` – SMTP settings editor.

## NuGet Packages

Included in `KlimaNotifier.csproj`:

- `Microsoft.Data.Sqlite`
- `Microsoft.Extensions.Configuration`
- `Microsoft.Extensions.Configuration.Json`
- `Microsoft.Toolkit.Uwp.Notifications`

## Build & Run (Visual Studio)

1. Open `KlimaNotifier.csproj` in Visual Studio 2022+.
2. Restore NuGet packages.
3. Ensure target framework is `.NET 7.0 (Windows)`.
4. Build and run (`F5`).

## Build & Run (VS Code + .NET SDK)

```bash
dotnet restore
dotnet build
cd bin/Debug/net7.0-windows
dotnet KlimaNotifier.dll
```

> Note: Windows toast notifications require running on Windows with notification permissions enabled.

## Test Workflow

1. Launch app.
2. Add a customer with purchase date exactly 30/180/365 days before today.
3. Click **Run Reminder Check**.
4. Verify:
   - Toast popup appears.
   - Email is delivered using configured SMTP server.
   - Customer reminder flag becomes `true` in grid.
   - Log entry appears in `logs` folder.

## Deployment Notes

- Publish with self-contained Windows runtime if required:

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

- Keep `smtpconfig.json` secured because it contains SMTP credentials.

## Inno Setup Installer

An installer script is included at:

- `installer/KlimaNotifierSetup.iss`

### What it does

- Installs app to `Program Files\KlimaNotifier`
- Optionally creates a desktop shortcut
- Adds app to Windows startup (`HKCU\Software\Microsoft\Windows\CurrentVersion\Run`)
- Includes `smtpconfig.json`
- Creates `logs` folder

### Build installer

1. Publish the application first:

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

2. Open `installer/KlimaNotifierSetup.iss` in Inno Setup Compiler.
3. Verify `MyPublishDir` points to your publish folder.
4. Compile script (`Build` in IDE or `ISCC KlimaNotifierSetup.iss`).
