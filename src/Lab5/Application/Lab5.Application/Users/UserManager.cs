using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Users.Contracts.Users;
using Lab5.Application.Users.Models.Accounts;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users;

public class UserManager : ICurrentUserManager
{
    private readonly IAccountRepository _accountRepository;

    public UserManager(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public User? User { get; set; }

    public IEnumerable<Account>? GetUsersAccounts()
    {
        if (User is null) return null;
        return _accountRepository.FindAccountsByName(User.Name);
    }
}