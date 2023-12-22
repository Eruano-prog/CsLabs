using Lab5.Application.Contracts.Users;

namespace Lab5.Presentation.Console.Scenarios;

public abstract class BaseScenarioChain : IScenario
{
    protected BaseScenarioChain(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public IScenario? NextScenario { get; private set; }
    public abstract void Run(IUserService userService);
    public virtual void Handle(string input, IUserService userService)
    {
        NextScenario?.Handle(input, userService);
    }

    public IScenario SetNext(IScenario scenarioNode)
    {
        NextScenario = scenarioNode;
        return this;
    }
}