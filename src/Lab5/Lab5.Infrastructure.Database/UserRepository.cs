using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Users;
using Npgsql;

namespace Lab5.Infrastructure;

public class UserRepository : IUserRepository
{
    private NpgsqlConnection _database;
    public UserRepository()
    {
        string connectionString = "Host=localhost:5432;" +
                                   "Username=postgres;" +
                                   "Password=fedor2004;" +
                                   "Database=postgresDB";
        _database = new NpgsqlConnection(connectionString);
        _database.Open();
    }

    public User? FindUserByName(string name)
    {
        throw new NotImplementedException();
    }
}