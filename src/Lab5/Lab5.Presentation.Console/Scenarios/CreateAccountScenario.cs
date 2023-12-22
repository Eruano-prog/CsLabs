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
        userService.CreateAccount();
        System.Console.WriteLine("Account Created!");
    }
}