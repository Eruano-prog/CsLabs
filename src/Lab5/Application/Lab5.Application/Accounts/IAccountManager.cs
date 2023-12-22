using Lab5.Application.Contracts.Orders;

namespace Lab5.Application.Accounts;

public interface IAccountManager
{
    long GetAccountBalance();
    OrderResults ChangeBalance(long cash);
}