using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class LoginScenario : BaseScenarioChain
{
    public LoginScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "login")
        {
            Run(userService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService)
    {
        System.Console.WriteLine("Type your username");
        string? username = System.Console.ReadLine();
        System.Console.WriteLine("Type your password");
        string? password = System.Console.ReadLine();
        if (username is null || password is null || userService is null) return;

        userService.Login(username, password);
    }
}