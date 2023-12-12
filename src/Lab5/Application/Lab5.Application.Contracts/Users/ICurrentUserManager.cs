using Lab5.Application.Users.Models.Accounts;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users.Contracts.Users;

public interface ICurrentUserManager
{
    User? User { get; set; }

    IEnumerable<Account>? GetUsersAccounts();
}