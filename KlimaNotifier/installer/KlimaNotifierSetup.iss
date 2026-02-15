; Inno Setup script for KlimaNotifier
; Build with Inno Setup Compiler (ISCC.exe)

#define MyAppName "KlimaNotifier"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "KlimaNotifier"
#define MyAppExeName "KlimaNotifier.exe"
; Update this path to your publish folder before building installer.
#define MyPublishDir "..\\bin\\Release\\net7.0-windows\\win-x64\\publish"

[Setup]
AppId={{C82D5F32-11A9-47A9-8D8A-1C0B767B9362}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputDir=.
OutputBaseFilename=KlimaNotifier-Setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "Create a &desktop shortcut"; GroupDescription: "Additional icons:"; Flags: unchecked
Name: "startup"; Description: "Start KlimaNotifier when Windows starts"; GroupDescription: "Startup options:"; Flags: checkedonce

[Files]
Source: "{#MyPublishDir}\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; Ensure smtpconfig.json is included even if publish profile changes.
Source: "..\smtpconfig.json"; DestDir: "{app}"; Flags: ignoreversion

[Dirs]
Name: "{app}\logs"

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Registry]
; Add app to current user's startup so it runs on login.
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\Run"; \
    ValueType: string; ValueName: "{#MyAppName}"; ValueData: '"{app}\{#MyAppExeName}"'; \
    Flags: uninsdeletevalue; Tasks: startup

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Launch {#MyAppName}"; Flags: nowait postinstall skipifsilent
