using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Accounts;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Application.Users.Models.Accounts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Test
{
    [Fact]
    public void GetMoneyTest()
    {
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOrderRepository orderRepository = Substitute.For<IOrderRepository>();
        var account = new Account(2, "test", 500);
        IAccountManager accountManager = new AccountManager(account, accountRepository);

        IUserService userService = new UserService(userRepository, accountRepository, orderRepository, accountManager);
        userService.GetMoney(200);

        accountRepository.Received(1).EditAccountBalance(account);
        Assert.Equal(300, account.Balance);
    }

    [Fact]
    public void NotEnoughMoneyTest()
    {
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOrderRepository orderRepository = Substitute.For<IOrderRepository>();
        var account = new Account(2, "test", 100);
        IAccountManager accountManager = new AccountManager(account, accountRepository);

        IUserService userService = new UserService(userRepository, accountRepository, orderRepository, accountManager);
        userService.GetMoney(200);

        accountRepository.Received(0).EditAccountBalance(account);
        Assert.Equal(100, account.Balance);
    }

    [Fact]
    public void PutMoneyTest()
    {
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IOrderRepository orderRepository = Substitute.For<IOrderRepository>();
        var account = new Account(2, "test", 100);
        IAccountManager accountManager = new AccountManager(account, accountRepository);

        IUserService userService = new UserService(userRepository, accountRepository, orderRepository, accountManager);
        userService.PutMoney(200);

        accountRepository.Received(1).EditAccountBalance(account);
        Assert.Equal(300, account.Balance);
    }
}