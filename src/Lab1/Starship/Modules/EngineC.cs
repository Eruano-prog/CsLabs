namespace Itmo.ObjectOrientedProgramming.Lab1.Starship.Modules;

public sealed class EngineC : BaseEngine
{
    private readonly int _speed;

    public EngineC()
    {
        _speed = 200;
        Consumption = 10;
        CanPassNitro = false;
    }

    public override int TimeToPass(int dist)
    {
        return dist / _speed;
    }
}