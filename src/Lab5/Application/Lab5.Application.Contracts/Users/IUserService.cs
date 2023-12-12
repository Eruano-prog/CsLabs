namespace Lab5.Application.Users.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string name, string password);
}