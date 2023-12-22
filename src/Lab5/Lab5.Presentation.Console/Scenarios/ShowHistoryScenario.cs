using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Transactions;

namespace Lab5.Presentation.Console.Scenarios;

public class ShowHistoryScenario : BaseScenarioChain
{
    public ShowHistoryScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "history")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (userService is null) return;

        IEnumerable<Order> list = userService.ShowHistory() ?? Array.Empty<Order>();

        System.Console.WriteLine("History of accounts:");
        foreach (Order order in list)
        {
            System.Console.WriteLine($"{order.AccountId} {order.Type} {order.Amount}");
        }
    }
}