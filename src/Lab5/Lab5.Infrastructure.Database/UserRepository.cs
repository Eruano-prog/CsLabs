using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString = "Host=localhost:5432;" +
                                               "Username=postgres;" +
                                               "Password=fedor2004;" +
                                               "Database=Lab5";

    public User? FindUserByName(string name)
    {
        var database = new NpgsqlConnection(_connectionString);
        database.Open();
        using var cmd = new NpgsqlCommand(
                        """
                            Select *
                            From "Lab5"."Entities"."Users"
                            Where "Name" = @name
                            """,
                        database);
        cmd.Parameters.AddWithValue("name", name);

        using NpgsqlDataReader reader = cmd.ExecuteReader();
        int id = reader.GetInt32(0);
        string username = reader.GetString(1);
        UserRole role = reader.GetBoolean(2) ? UserRole.Admin : UserRole.Common;
        string password = reader.GetString(3);

        database.Close();
        return new User(id, username, role, password);
    }
}