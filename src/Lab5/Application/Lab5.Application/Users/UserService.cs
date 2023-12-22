using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;
using Lab5.Application.Users.Models.Users;

namespace Lab5.Application.Users;

public class UserService : IUserService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private User? _user;
    private IAccountManager? _accountManager;

    public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _orderRepository = orderRepository;
    }

    public LoginResult Login(string name, string password)
    {
        User? user = _userRepository.FindUserByName(name);

        if (user is null) return new LoginNotFound();

        if (user.Password != password) return new LoginWrongPassword();

        _user = user;
        return new LoginSuccess();
    }

    public IEnumerable<Account>? GetUsersAccounts()
    {
        if (_user is null) return null;
        IEnumerable<Account> accounts = _accountRepository.FindAccountsByName(_user.Name);

        return accounts;
    }

    public void ChooseAccount(int id)
    {
        Account? account = _accountRepository.FindAccountById(id);
        if (account is null) return;

        _accountManager = new AccountLoggerDecorator(account, _accountRepository, _orderRepository);
    }

    public void CreateAccount()
    {
        if (_user is null) return;
        _accountRepository.CreateAccount(_user.Name);
    }

    public long GetBalance()
    {
        if (_accountManager is null) return -1;
        return _accountManager.GetAccountBalance();
    }

    public void GetMoney(int sum)
    {
        if (_accountManager is null) return;
        _accountManager.ChangeBalance(-sum);
    }

    public void PutMoney(int amount)
    {
        if (_accountManager is null) return;
        _accountManager.ChangeBalance(amount);
    }

    public IEnumerable<Order>? ShowHistory()
    {
        if (_user is null) return null;
        return _orderRepository.GetHistoryByUser(_user.Name);
    }
}