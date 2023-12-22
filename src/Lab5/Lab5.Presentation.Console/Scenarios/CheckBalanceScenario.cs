using Lab5.Application.Contracts.Users;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios;

public class CheckBalanceScenario : BaseScenarioChain
{
    public CheckBalanceScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "balance")
        {
            Run(userService);
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService)
    {
        if (userService is null) return;
        IEnumerable<Account>? accounts = userService.GetUsersAccounts();

        if (accounts is null) return;
        foreach (Account account in accounts)
        {
            System.Console.WriteLine($"{account.Id}\t{account.Balance}");
        }
    }
}