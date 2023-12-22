using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Orders;
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

    public OrderResults ChangeBalance(long cash)
    {
        OrderResults result = _accountManager.ChangeBalance(cash);
        if (result is OrderResults.NotEnoughMoney)
        {
            return result;
        }

        OrderType orderType = cash >= 0 ? OrderType.Put : OrderType.Get;
        _orderRepository.AddOrder(new Order(_account.Id, cash, _account.Host, orderType));
        return result;
    }
}