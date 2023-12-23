using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Contracts.Users;

public interface IAdminService
{
    LoginResult Login(string password);
    IEnumerable<Account>? FindUsersAccount(string username);
    IEnumerable<Order>? ViewUsersHistory(string username);
}