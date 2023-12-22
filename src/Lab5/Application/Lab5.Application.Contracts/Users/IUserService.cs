using Lab5.Application.Contracts.Orders;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    IEnumerable<Account>? GetUsersAccounts();
    public LoginResult ChooseAccount(int id);
    public OrderResults CreateAccount();
    public long GetBalance();
    public OrderResults GetMoney(int sum);
    public OrderResults PutMoney(int amount);
    public IEnumerable<Order>? ShowHistory();
    LoginResult Login(string name, string password);
}