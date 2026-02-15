using KlimaNotifier.Models;
using Microsoft.Data.Sqlite;

namespace KlimaNotifier.Data;

/// <summary>
/// Basic data-access layer for Customers table.
/// </summary>
public sealed class CustomerRepository
{
    private readonly string _connectionString;

    public CustomerRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<Customer> GetAll()
    {
        var list = new List<Customer>();
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = @"SELECT id, firstName, lastName, phone, email, purchaseDate, reminder30Sent, reminder180Sent, reminder365Sent
                            FROM Customers ORDER BY id DESC;";

        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Customer
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                Email = reader.GetString(4),
                PurchaseDate = DateTime.Parse(reader.GetString(5)).Date,
                Reminder30Sent = reader.GetInt32(6) == 1,
                Reminder180Sent = reader.GetInt32(7) == 1,
                Reminder365Sent = reader.GetInt32(8) == 1
            });
        }

        return list;
    }

    public void Add(Customer customer)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = @"INSERT INTO Customers(firstName,lastName,phone,email,purchaseDate,reminder30Sent,reminder180Sent,reminder365Sent)
                            VALUES($firstName,$lastName,$phone,$email,$purchaseDate,0,0,0);";
        cmd.Parameters.AddWithValue("$firstName", customer.FirstName);
        cmd.Parameters.AddWithValue("$lastName", customer.LastName);
        cmd.Parameters.AddWithValue("$phone", customer.Phone);
        cmd.Parameters.AddWithValue("$email", customer.Email);
        cmd.Parameters.AddWithValue("$purchaseDate", customer.PurchaseDate.ToString("yyyy-MM-dd"));
        cmd.ExecuteNonQuery();
    }

    public void MarkReminderSent(int customerId, int day)
    {
        string column = day switch
        {
            30 => "reminder30Sent",
            180 => "reminder180Sent",
            365 => "reminder365Sent",
            _ => throw new ArgumentOutOfRangeException(nameof(day), "Only 30/180/365 are supported.")
        };

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var cmd = connection.CreateCommand();
        cmd.CommandText = $"UPDATE Customers SET {column} = 1 WHERE id = $id";
        cmd.Parameters.AddWithValue("$id", customerId);
        cmd.ExecuteNonQuery();
    }
}
