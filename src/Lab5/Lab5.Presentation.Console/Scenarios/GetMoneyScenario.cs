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
            userService.GetMoney(sum);
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}