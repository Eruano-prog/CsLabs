using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console;

public class ScenarioRunner
{
    private readonly IScenario _scenarioChain;
    private readonly IUserService _userService;

    public ScenarioRunner(IScenario scenarioChain, IUserService userService)
    {
        _scenarioChain = scenarioChain;
        _userService = userService;
    }

    public void Run()
    {
        string? input = "begin";
        while (input != "end")
        {
            System.Console.WriteLine("Type command you want:");

            input = System.Console.ReadLine();
            if (input is null) return;

            _scenarioChain.Handle(input, _userService);
        }
    }
}