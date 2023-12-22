using Lab5.Application.Contracts.Orders;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class GetMoneyScenario : BaseScenarioChain
{
    public GetMoneyScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "get")
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
            OrderResults result = userService.GetMoney(sum);
            if (result is OrderResults.Success) System.Console.WriteLine("You got your money");
            else if (result is OrderResults.AccountNotChosen) System.Console.WriteLine("Please choose account first");
            else if (result is OrderResults.NotEnoughMoney) System.Console.WriteLine("Not enough money on chosen account");
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}