using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Infrastructure;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Scenarios;

IUserRepository userRepository = new UserRepository();
IAccountRepository accountRepository = new AccountRepository();

IScenario scenarioChain = new LoginScenario("login");
scenarioChain.SetNext(new CheckBalanceScenario("balance")
        .SetNext(new GetMoneyScenario("get")
        .SetNext(new ChooseAccountScenario("choose"))));

IUserService userService = new UserService(userRepository, accountRepository);
var scenario = new ScenarioRunner(scenarioChain, userService);

scenario.Run();