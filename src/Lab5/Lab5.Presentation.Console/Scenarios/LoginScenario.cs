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
            Run(userService, adminService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        System.Console.WriteLine("Type your username");
        string? username = System.Console.ReadLine();
        System.Console.WriteLine("Type your password");
        string? password = System.Console.ReadLine();
        if (username is null || password is null || userService is null || adminService is null) return;

        LoginResult result;
        if (username == "Admin")
        {
            result = adminService.Login(password);
            if (result is LoginSuccess) System.Console.WriteLine("You logged as Admin!");
            else System.Console.WriteLine("Your password is incorrect");
            return;
        }

        result = userService.Login(username, password);
        if (result is LoginSuccess) System.Console.WriteLine("You logged into account!");
        else if (result is LoginNotFound) System.Console.WriteLine("This user is not found");
        else if (result is LoginWrongPassword) System.Console.WriteLine("Your password is incorrect");
    }
}