namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    void FindUsersAccount(string username);
    void EditUsersAccountBalance(string username, int id, int balance);
}