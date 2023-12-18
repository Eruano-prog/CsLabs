using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Accounts;

public class AccountManager : IAccountManager
{
    private IAccountRepository _accountRepository;
    private Account _account;
    public AccountManager(Account account, IAccountRepository accountRepository)
    {
        _account = account;
        _accountRepository = accountRepository;
    }

    public long GetAccountBalance()
    {
        return _account.Balance;
    }

    public void ChangeBalance(long cash)
    {
        _account.Balance += cash;
        SaveChanges();
    }

    private void SaveChanges()
    {
        _accountRepository.SaveAccount(_account);
    }
}