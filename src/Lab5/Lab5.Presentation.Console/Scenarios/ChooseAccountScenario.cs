using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class ChooseAccountScenario : BaseScenarioChain
{
    public ChooseAccountScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService, IAdminService adminService)
    {
        if (input == "choose")
        {
            Run(userService, adminService);
            return;
        }

        base.Handle(input, userService, adminService);
    }

    public override void Run(IUserService userService, IAdminService adminService)
    {
        if (userService is null) return;

        System.Console.WriteLine("Enter id of account:");
        string? idStr = System.Console.ReadLine();

        if (int.TryParse(idStr, out int id))
        {
            LoginResult result = userService.ChooseAccount(id);

            if (result is LoginSuccess) System.Console.WriteLine("You`ve chosen it");
            else if (result is LoginNotFound) System.Console.WriteLine("Account with this id not found");
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}