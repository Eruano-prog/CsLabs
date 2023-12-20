using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private User? _user;
    private AccountManager? _accountManager;

    public UserService(IUserRepository userRepository, IAccountRepository accountRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
    }

    public LoginResult Login(string name, string password)
    {
        User? user = _userRepository.FindUserByName(name);

        if (user is null) return new LoginNotFound();

        if (user.Password != password) return new LoginWrongPassword();

        _user = user;
        return new LoginSuccess();
    }

    public IEnumerable<int>? GetUsersAccounts()
    {
        if (_user is null) return null;
        IEnumerable<Account> accounts = _accountRepository.FindAccountsByName(_user.Name);

        IEnumerable<int> result = accounts.Select(a => a.Id);

        return result;
    }

    public void ChooseAccount(int id)
    {
        Account? account = _accountRepository.FindAccountById(id);
        if (account is null) return;

        _accountManager = new AccountManager(account, _accountRepository);
    }

    public void CreateAccount()
    {
        throw new NotImplementedException();
    }

    public int GetBalance()
    {
        throw new NotImplementedException();
    }

    public int GetMoney()
    {
        throw new NotImplementedException();
    }

    public void PutMoney(int amount)
    {
        throw new NotImplementedException();
    }

    public void ShowHistory()
    {
        throw new NotImplementedException();
    }
}