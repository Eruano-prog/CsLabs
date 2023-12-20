namespace Lab5.Application.Contracts.Users;

public interface IUserService
{
    IEnumerable<int>? GetUsersAccounts();
    public void ChooseAccount(int id);
    public void CreateAccount();
    public int GetBalance();
    public int GetMoney();
    public void PutMoney(int amount);
    public void ShowHistory();
    LoginResult Login(string name, string password);
}