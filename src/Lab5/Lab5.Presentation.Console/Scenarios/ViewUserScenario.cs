using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;

namespace Lab5.Presentation.Console.Scenarios;

public class ViewUserScenario : BaseScenarioChain
{
    public ViewUserScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "viewUser")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (adminService is null) return;
        System.Console.WriteLine("Enter user to view:");
        string? username = System.Console.ReadLine();
        if (username is null) return;

        IEnumerable<Order> list = adminService.ViewUsersHistory(username) ?? Array.Empty<Order>();

        foreach (Order order in list)
        {
            System.Console.WriteLine($"{order.AccountId} {order.Type} {order.Amount}");
        }
    }
}