using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class ChooseAccountScenario : BaseScenarioChain
{
    public ChooseAccountScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService)
    {
        if (input == "choose")
        {
            Run(userService);
            return;
        }

        base.Handle(input, userService);
    }

    public override void Run(IUserService userService)
    {
        if (userService is null) return;

        System.Console.WriteLine("Enter id of account:");
        string? idStr = System.Console.ReadLine();

        if (int.TryParse(idStr, out int id))
        {
            userService.ChooseAccount(id);
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}