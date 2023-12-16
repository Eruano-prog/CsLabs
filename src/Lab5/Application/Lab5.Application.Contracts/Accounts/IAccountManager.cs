namespace Lab5.Application.Users.Contracts.Accounts;

public interface IAccountManager
{
    long GetAccountBalance();
    void ChangeBalance(long cash);
}