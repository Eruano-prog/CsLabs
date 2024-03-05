using Lab5.Application.Contracts.Users;
using Lab5.Presentation.Console.Scenarios;

namespace Lab5.Presentation.Console;

public class ScenarioRunner
{
    private readonly IScenario _scenarioChain;
    private readonly IUserService _userService;
    private readonly IAdminService _adminService;

    public ScenarioRunner(IUserService userService, IAdminService adminService)
    {
        _scenarioChain = BuildDefaultChain();
        _userService = userService;
        _adminService = adminService;
    }

    public void Run()
    {
        string? input = "begin";
        while (input != "end")
        {
            System.Console.WriteLine("Type command you want:");

            input = System.Console.ReadLine();
            if (input is null) return;

            _scenarioChain.Handle(input, _userService, _adminService);
        }
    }

    private static IScenario BuildDefaultChain()
    {
        IScenario scenarioChain = new LoginScenario("login");
        scenarioChain.SetNext(new CheckBalanceScenario("balance")
            .SetNext(new GetMoneyScenario("get")
                .SetNext(new ChooseAccountScenario("choose")
                    .SetNext(new PutMoneyScenario("put")
                        .SetNext(new CreateAccountScenario("create")
                            .SetNext(new ShowHistoryScenario("history")
                                .SetNext(new FindUsersAccount("findAccount")
                                    .SetNext(new ViewUserScenario("viewUser")))))))));

        return scenarioChain;
    }
}