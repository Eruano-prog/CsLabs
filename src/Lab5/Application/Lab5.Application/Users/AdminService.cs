using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Application.Users;

public class AdminService : IAdminService
{
    private IUserRepository _userRepository;
    private IAccountRepository _accountRepository;
    private IOrderRepository _orderRepository;
    private string _password = "123";
    private bool _logged;

    public AdminService(IUserRepository userRepository, IAccountRepository accountRepository, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _orderRepository = orderRepository;
    }

    public LoginResult Login(string password)
    {
        if (password == _password)
        {
            _logged = true;
            return new LoginSuccess();
        }

        return new LoginWrongPassword();
    }

    public IEnumerable<Account>? FindUsersAccount(string username)
    {
        if (_logged)
        {
            return _accountRepository.FindAccountsByName(username);
        }

        return null;
    }

    public IEnumerable<Order>? ViewUsersHistory(string username)
    {
        if (_logged)
        {
            return _orderRepository.GetHistoryByUser(username);
        }

        return null;
    }
}