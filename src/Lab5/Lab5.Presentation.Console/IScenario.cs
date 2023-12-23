using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console;

public interface IScenario
{
    string Name { get; }
    IScenario? NextScenario { get; }

    void Run(IUserService userService, IAdminService adminService);
    void Handle(string input, IUserService userService, IAdminService adminService);
    IScenario SetNext(IScenario scenarioNode);
}