using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Accounts;

public class AccountLoggerDecorator : IAccountManager
{
    private AccountManager _accountManager;
    private IOrderRepository _orderRepository;
    private Account _account;

    public AccountLoggerDecorator(Account account, IAccountRepository accountRepository, IOrderRepository orderRepository)
    {
        _account = account;
        _orderRepository = orderRepository;
        _accountManager = new AccountManager(account, accountRepository);
    }

    public long GetAccountBalance()
    {
        return _accountManager.GetAccountBalance();
    }

    public void ChangeBalance(long cash)
    {
        OrderType orderType = cash >= 0 ? OrderType.Put : OrderType.Get;
        _orderRepository.AddOrder(new Order(_account.Id, cash, _account.Host, orderType));
        _accountManager.ChangeBalance(cash);
    }
}