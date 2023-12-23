using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Users;
using Lab5.Application.Users.Abstractions.Repositories;
using Lab5.Infrastructure;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Scenarios;

string connectionString = "Host=localhost:5432;" +
                          "Username=postgres;" +
                          "Password=fedor2004;" +
                          "Database=Lab5";
IUserRepository userRepository = new UserRepository(connectionString);
IAccountRepository accountRepository = new AccountRepository(connectionString);
IOrderRepository orderRepository = new OrderRepository(connectionString);

IScenario scenarioChain = new LoginScenario("login");
scenarioChain.SetNext(new CheckBalanceScenario("balance")
    .SetNext(new GetMoneyScenario("get")
        .SetNext(new ChooseAccountScenario("choose")
            .SetNext(new PutMoneyScenario("put")
                .SetNext(new CreateAccountScenario("create")
                    .SetNext(new ShowHistoryScenario("history")
                        .SetNext(new FindUsersAccount("findAccount")
                            .SetNext(new ViewUserScenario("viewUser")))))))));

IUserService userService = new UserService(userRepository, accountRepository, orderRepository);
IAdminService adminService = new AdminService("123", userRepository, accountRepository, orderRepository);

var scenario = new ScenarioRunner(scenarioChain, userService, adminService);

scenario.Run();