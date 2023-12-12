using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Contracts.Users;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserManager _userManager;

    public UserService(IUserRepository userRepository, ICurrentUserManager userManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
    }

    public LoginResult Login(string name, string password)
    {
        User? user = _userRepository.FindUserByName(name);

        if (user is null) return new LoginNotFound();

        if (user.Password != password) return new LoginWrongPassword();

        _userManager.User = user;
        return new LoginSuccess();
    }
}