using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Orders;
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
    private IAccountManager? _accountManager;
    private User? _user;

    public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _orderRepository = orderRepository;
    }

    public UserService(IUserRepository userRepository, IAccountRepository accountRepository, IOrderRepository orderRepository, IAccountManager accountManager)
    {
        _userRepository = userRepository;
        _accountRepository = accountRepository;
        _orderRepository = orderRepository;
        _accountManager = accountManager;
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

    public LoginResult ChooseAccount(int id)
    {
        Account? account = _accountRepository.FindAccountById(id);
        if (account is null) return new LoginNotFound();

        _accountManager = new AccountLoggerDecorator(account, _accountRepository, _orderRepository);
        return new LoginSuccess();
    }

    public OrderResults CreateAccount()
    {
        if (_user is null) return OrderResults.AccountNotChosen;
        _accountRepository.CreateAccount(_user.Name);
        return OrderResults.Success;
    }

    public long GetBalance()
    {
        if (_accountManager is null) return -1;
        return _accountManager.GetAccountBalance();
    }

    public OrderResults GetMoney(int sum)
    {
        if (_accountManager is null) return OrderResults.AccountNotChosen;
        return _accountManager.ChangeBalance(-sum);
    }

    public OrderResults PutMoney(int amount)
    {
        if (_accountManager is null) return OrderResults.AccountNotChosen;
        _accountManager.ChangeBalance(amount);
        return OrderResults.Success;
    }

    public IEnumerable<Order>? ShowHistory()
    {
        if (_user is null) return null;
        return _orderRepository.GetHistoryByUser(_user.Name);
    }
}