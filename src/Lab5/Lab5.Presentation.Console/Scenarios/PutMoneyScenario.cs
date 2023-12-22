using Lab5.Application.Contracts.Orders;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class PutMoneyScenario : BaseScenarioChain
{
    public PutMoneyScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "put")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (userService is null) return;

        System.Console.WriteLine("Enter sum:");
        string? answer = System.Console.ReadLine();

        if (int.TryParse(answer, out int sum))
        {
            OrderResults results = userService.PutMoney(sum);
            if (results is OrderResults.Success) System.Console.WriteLine("You put your money to account");
            else if (results is OrderResults.AccountNotChosen) System.Console.WriteLine("Choose account first");
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}