using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Users.Contracts.Accounts;

public interface IAccountManager
{
    Account? Account { get; }
    void SetAccount(string user, int id);
    long GetAccountBalance();
    void ChangeBalance(long cash);
}