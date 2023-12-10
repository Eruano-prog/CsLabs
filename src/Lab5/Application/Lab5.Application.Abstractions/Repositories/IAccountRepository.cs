using Lab5.Application.Models.Account;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account? FindAccountById(int id);
}