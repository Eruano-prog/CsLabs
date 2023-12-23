using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users.Abstractions.Repositories;

public interface IUserRepository
{
    User? FindUserByName(string name);
}