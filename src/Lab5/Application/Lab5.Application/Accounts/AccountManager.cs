using Lab5.Application.Users.Contracts.Accounts;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Accounts;

public class AccountManager : IAccountManager
{
    public Account? Account { get; }

    public void SetAccount(string user, int id)
    {
        throw new NotImplementedException();
    }

    public long GetAccountBalance()
    {
        throw new NotImplementedException();
    }

    public void ChangeBalance(long cash)
    {
        throw new NotImplementedException();
    }
}