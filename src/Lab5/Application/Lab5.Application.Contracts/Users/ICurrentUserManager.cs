using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Contracts.Users;

public interface ICurrentUserManager
{
    User? User { get; set; }

    IEnumerable<int>? GetUsersAccounts();
    public void ChooseAccount(int id);
    public void CreateAccount();
    public int GetBalance();
    public int GetMoney();
    public void PutMoney(int amount);
    public void ShowHistory();
}