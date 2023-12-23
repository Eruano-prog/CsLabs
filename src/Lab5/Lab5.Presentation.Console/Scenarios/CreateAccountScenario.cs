using Lab5.Application.Contracts.Orders;
using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class CreateAccountScenario : BaseScenarioChain
{
    public CreateAccountScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "create")
        {
            Run(userService, adminService);
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (userService is null) return;
        OrderResults result = userService.CreateAccount();
        if (result is OrderResults.Success) System.Console.WriteLine("Account Created!");
        else if (result is OrderResults.AccountNotChosen) System.Console.WriteLine("Login first");
    }
}