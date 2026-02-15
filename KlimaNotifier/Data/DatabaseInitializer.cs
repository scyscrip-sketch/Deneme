using Microsoft.Data.Sqlite;
using KlimaNotifier.Services;

namespace KlimaNotifier.Data;

/// <summary>
/// Creates/opens local SQLite database and performs schema migration.
/// </summary>
public sealed class DatabaseInitializer
{
    private readonly string _dbPath;
    private readonly FileLogger _logger;

    public DatabaseInitializer(string basePath, FileLogger logger)
    {
        _dbPath = Path.Combine(basePath, "klimanotifier.db");
        _logger = logger;
    }

    public string ConnectionString => $"Data Source={_dbPath}";

    public void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        const string sql = @"
CREATE TABLE IF NOT EXISTS Customers (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    firstName TEXT NOT NULL,
    lastName TEXT NOT NULL,
    phone TEXT,
    email TEXT NOT NULL,
    purchaseDate TEXT NOT NULL,
    reminder30Sent INTEGER NOT NULL DEFAULT 0,
    reminder180Sent INTEGER NOT NULL DEFAULT 0,
    reminder365Sent INTEGER NOT NULL DEFAULT 0
);";

        using var cmd = connection.CreateCommand();
        cmd.CommandText = sql;
        cmd.ExecuteNonQuery();

        _logger.LogInfo("Database initialized successfully.");
    }
}
