using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure;

public class OrderRepository : IOrderRepository
{
    private readonly string _connectionString;

    public OrderRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void AddOrder(Order transaction)
    {
        if (transaction is null) return;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var cmd = new NpgsqlCommand(
            """
            Insert into "Lab5"."Entities"."OrderHistory" ("AccountId", "Amount", "HostName", "Type")
            VALUES (@accountId, @amount, @hostName, @orderType)
            """,
            connection);

        cmd.Parameters.AddWithValue("accountId", transaction.AccountId);
        cmd.Parameters.AddWithValue("amount", transaction.Amount);
        cmd.Parameters.AddWithValue("hostName", transaction.Username);
        cmd.Parameters.AddWithValue("orderType", transaction.Type.ToString());

        using NpgsqlDataReader reader = cmd.ExecuteReader();
    }

    public IEnumerable<Order>? GetHistoryByUser(string username)
    {
        if (username is null) return null;
        var result = new List<Order>();

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        using var cmd = new NpgsqlCommand(
            """
            Select *
            From "Lab5"."Entities"."OrderHistory"
            Where "HostName" = @name
            """,
            connection);

        cmd.Parameters.AddWithValue("name", username);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(1);
            string host = reader.GetString(3);
            long balance = reader.GetInt32(2);
            string type = reader.GetString(4);
            OrderType orderType = type == "get" ? OrderType.Get : OrderType.Put;
            result.Add(new Order(id, balance, host, orderType));
        }

        return result;
    }
}