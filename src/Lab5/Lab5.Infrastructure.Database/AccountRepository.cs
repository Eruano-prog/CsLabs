using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;
using Npgsql;

namespace Lab5.Infrastructure;

public class AccountRepository : IAccountRepository
{
    private readonly string _connectionString = "Host=localhost:5432;" +
                                                "Username=postgres;" +
                                                "Password=fedor2004;" +
                                                "Database=Lab5";

    public Account? FindAccountById(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT *
            FROM "Entities"."Accounts"
            WHERE "Id" = @id
            """,
            connection);
        cmd.Parameters.AddWithValue("id", id);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        int ids = reader.GetInt32(0);
        string host = reader.GetString(1);
        long balance = reader.GetInt32(2);

        return new Account(ids, host, balance);
    }

    public IEnumerable<Account> FindAccountsByName(string name)
    {
        var result = new List<Account>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
            SELECT *
            FROM "Entities"."Accounts"
            WHERE "Host" = @name
            Order by "Id"
            """,
            connection);
        cmd.Parameters.AddWithValue("name", name);
        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string host = reader.GetString(1);
            long balance = reader.GetInt32(2);
            result.Add(new Account(id, host, balance));
        }

        return result;
    }

    public void EditAccountBalance(Account account)
    {
        if (account is null) return;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
                    Update "Entities"."Accounts"
                    set "Balance" = @balance
                    Where "Id" = @id
                    """,
            connection);
        cmd.Parameters.AddWithValue("balance", account.Balance);
        cmd.Parameters.AddWithValue("id", account.Id);
        cmd.ExecuteReader();
    }

    public void CreateAccount(string host)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        using var cmd = new NpgsqlCommand(
            """
                    INSERT INTO "Entities"."Accounts" as ac ("Host", "Balance")
                    VALUES (@host, @balance)
            """,
            connection);
        cmd.Parameters.AddWithValue("name", host);
        cmd.Parameters.AddWithValue("name", host);
        using NpgsqlDataReader reader = cmd.ExecuteReader();
    }
}