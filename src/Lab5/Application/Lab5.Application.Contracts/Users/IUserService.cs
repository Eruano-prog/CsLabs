using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    IEnumerable<Account>? GetUsersAccounts();
    public void ChooseAccount(int id);
    public void CreateAccount();
    public long GetBalance();
    public void GetMoney(int sum);
    public void PutMoney(int amount);
    public IEnumerable<Order>? ShowHistory();
    LoginResult Login(string name, string password);
}