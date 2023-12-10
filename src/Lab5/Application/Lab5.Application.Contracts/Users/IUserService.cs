namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string name, string password);
}