using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public class PutMoneyScenario : BaseScenarioChain
{
    public PutMoneyScenario(string name)
        : base(name)
    {
    }

    public override void Handle(string input, IUserService userService)
    {
        if (input == "put")
        {
            Run(userService);
            return;
        }

        base.Handle(input, userService);
    }

    public override void Run(IUserService userService)
    {
        if (userService is null) return;

        System.Console.WriteLine("Enter sum:");
        string? answer = System.Console.ReadLine();

        if (int.TryParse(answer, out int sum))
        {
            userService.PutMoney(sum);
        }
        else
        {
            System.Console.WriteLine("Unable to parse answer to int");
        }
    }
}