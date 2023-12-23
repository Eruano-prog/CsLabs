using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Orders;
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

    public OrderResults ChangeBalance(long cash)
    {
        _account.Balance += cash;
        if (_account.Balance < 0)
        {
            _account.Balance -= cash;
            return OrderResults.NotEnoughMoney;
        }

        SaveChanges();
        return OrderResults.Success;
    }

    private void SaveChanges()
    {
        _accountRepository.EditAccountBalance(_account);
    }
}