using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? FindAccountById(int id);
    IEnumerable<Account> FindAccountsByName(string name);
}