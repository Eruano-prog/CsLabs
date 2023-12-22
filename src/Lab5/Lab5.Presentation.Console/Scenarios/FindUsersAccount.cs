using Lab5.Application.Contracts.Users;
using Lab5.Application.Users.Models.Accounts;

namespace Lab5.Presentation.Console.Scenarios;

public class FindUsersAccount : BaseScenarioChain
{
    public FindUsersAccount(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "viewAccounts")
        {
            Run(userService, adminService);
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (adminService is null) return;

        System.Console.WriteLine("Enter user to view:");
        string? username = System.Console.ReadLine();
        if (username is null) return;

        IEnumerable<Account> accounts = adminService.FindUsersAccount(username) ?? new List<Account>();

        foreach (Account account in accounts)
        {
            System.Console.WriteLine($"{account.Id}\t{account.Balance}");
        }
    }
}