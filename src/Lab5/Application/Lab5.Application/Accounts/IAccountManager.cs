namespace Lab5.Application.Accounts;

public interface IAccountManager
{
    long GetAccountBalance();
    void ChangeBalance(long cash);
}