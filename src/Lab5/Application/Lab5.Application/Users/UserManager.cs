using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users.Models.Accounts;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users;

public class UserManager : ICurrentUserManager
{
    private readonly IAccountRepository _accountRepository;
    private AccountManager? _accountManager;

    public UserManager(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public User? User { get; set; }

    public IEnumerable<int>? GetUsersAccounts()
    {
        if (User is null) return null;
        IEnumerable<Account> accounts = _accountRepository.FindAccountsByName(User.Name);

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