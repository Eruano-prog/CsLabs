namespace Itmo.ObjectOrientedProgramming.Lab1.Engine.Entities;

public sealed class EngineC : IEngine
{
    private readonly int _speed;

    public EngineC()
    {
        _speed = 200;
        Consumption = 10;
    }

    public int Consumption { get; }

    public int TimeToReach(int dist)
    {
        return dist / _speed;
    }
}